using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ObstacleSpawn : MonoBehaviour
{
    public float speed;

    private float timer;
    [SerializeField] private float timerStart;
    [SerializeField] private GameObject spawner, obstacles;

    void Start()
    {
        timer = timerStart;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            Spawn();
            timer = timerStart;
        }
    }

    void Spawn()
    {
        GameObject Obstacles = Instantiate(obstacles, spawner.transform.position, Quaternion.identity);
        Obstacles.transform.localScale = new Vector3(Camera.main.aspect * 1.8f, 1f, 1f);
        Obstacles.GetComponent<Rigidbody2D>().AddForce(Vector2.down * speed);
    }
}
