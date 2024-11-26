using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnControll : MonoBehaviour
{
    [SerializeField] GameObject[] Fruits;
    [SerializeField] GameObject Hearth;
    [SerializeField] GameObject[] Spawners;
    [SerializeField] float timerStart;

    public GameObject spawner;
    public float speed;

    private float timer;

    private void Start()
    {
        timerStart = UpgradeLoader.spawnRate;

        Spawners = new GameObject[ScreenResize.number_of_spawners];
        Spawners[0] = Instantiate(spawner, new Vector3(ScreenResize.minX_offset, 6f), Quaternion.identity);
        for (int i = 1; i < ScreenResize.number_of_spawners; i++)
        {
            if (Spawners[i - 1].transform.position.x < ScreenResize.maxX_offset - 0.5f)
            {
                Spawners[i] = Instantiate(spawner, Spawners[i - 1].transform.position + new Vector3(0.5f, 0, 0), spawner.transform.rotation);
            }
            else Spawners[i] = Instantiate(spawner, new Vector3(ScreenResize.maxX_offset, 0, 0), spawner.transform.rotation);
        }

        timer = timerStart;
    }

    void Update()
    {

        if(Spawners.Length != ScreenResize.number_of_spawners)
        {
            foreach (GameObject spawner in Spawners)
            {
                Destroy(spawner);
            }

            Spawners = new GameObject[ScreenResize.number_of_spawners];
            Spawners[0] = Instantiate(spawner, new Vector3(ScreenResize.minX_offset, 6f), Quaternion.identity);
            
            for (int i = 1; i < ScreenResize.number_of_spawners; i++)
            {
                if (Spawners[i - 1].transform.position.x < ScreenResize.maxX_offset - 0.5f)
                {
                    Spawners[i] = Instantiate(spawner, Spawners[i - 1].transform.position + new Vector3(0.5f, 0, 0), spawner.transform.rotation);
                }
                else Spawners[i] = Instantiate(spawner, new Vector3(ScreenResize.maxX_offset, 0, 0), spawner.transform.rotation);
            }
        }

        timer -= Time.deltaTime;

        if (timer < 0)
        {
            Spawn(Fruits[Random.Range(0, Fruits.Length)], Spawners[Random.Range(0, Spawners.Length)]);
            timer = timerStart;
            if (UpgradeLoader.hpDrop)
            {
                HearthCheck();
            }
        }
    }

    void Spawn( GameObject fruit, GameObject spawner)
    {
       GameObject FruitObject = Instantiate(fruit, spawner.transform.position, Quaternion.identity);
        FruitObject.GetComponent<Rigidbody2D>().AddForce(Vector2.down * speed);
    }

    void HearthCheck()
    {
        float chance = Random.value;
        if(chance > 0.95f)
        {
            Spawn(Hearth, Spawners[Random.Range(0, Spawners.Length)]);
        }
    }
}
