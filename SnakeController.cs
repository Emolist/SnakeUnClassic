using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class SnakeController : MonoBehaviour
{
    public float moveSpeed, rotationSpeed, length;
    public int score;
    public Collector collector_class;
    public SceneChange scene_change;
    public PickUpSoundHolder pickUpSound;

    [SerializeField] private Tail tailScript;
    [SerializeField] private TotalScore totalScore;
    [SerializeField] private GameObject shopButton;

    void Start()
    {
        score = 1;
        length = 10f;
        moveSpeed = UpgradeLoader.speed;
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = Vector2.MoveTowards(transform.position, mousePosition, moveSpeed * Time.deltaTime);
        }

        if (Input.touchCount > 0)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            transform.position = Vector2.MoveTowards(transform.position, mousePosition, moveSpeed * Time.deltaTime);
        }

        transform.position = new Vector3 (Mathf.Clamp(transform.position.x, ScreenResize.minX, ScreenResize.maxX), Mathf.Clamp(transform.position.y, -5f, 5f), 0);
       
        Vector3 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle - 90f, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);


        if(collector_class.lost)
        {
            Time.timeScale = 0;
            if (!scene_change.stoping)
            {
                shopButton.SetActive(true);
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Food")
        {
            FruitClass fruit = collision.GetComponent<FruitClass>();
            pickUpSound.RandomFruitSound();
            score += fruit.Value;
            length++;
            ChangeLength(length);
            int val = fruit.Value;
            collector_class.Collect(val);
            fruit.Delete();
        }

        if(collision.tag == "Obstacle")
        {
            FigurineObstacles obs = collision.GetComponent<FigurineObstacles>();
            pickUpSound.ObstacleSoundPlay();
            collector_class.Lose(obs.figure, obs.number);
            obs.Pass();
            totalScore.score++;
        }

        if(collision.tag == "Spike")
        {
            pickUpSound.SpikeSoundPlay();
            collision.GetComponent<FruitClass>().Delete();
            if (UpgradeLoader.spikeEadible)
            {
                score++;
            }
            else
            {
                length -= 10f;
                ChangeLength(length);
                collector_class.Lose();
            }
        }

        if(collision.tag == "Hearth")
        {
            pickUpSound.HearthSoundPlay();
            collector_class.GainHealth();
            collision.GetComponent<FruitClass>().Delete();
        }

    }

    private void ChangeLength(float current_length)
    {
        if(current_length < 10f)
        {
            current_length = 10f;
        }
        tailScript.targetDist = current_length/1000f;
    }
}
