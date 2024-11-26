using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private SnakeController snakeController;
    private Canvas canvas;

    public GameObject obstacleText;
    private GameObject obs;
    public int value;
    
    void Start()
    {
        snakeController = GameObject.FindGameObjectWithTag("Player").GetComponent<SnakeController>();
        canvas = GameObject.FindGameObjectWithTag("Canvas").GetComponent<Canvas>();
        obs = Instantiate(obstacleText, canvas.transform);
        obs.GetComponent<ObstacleText>().obstacle = this.gameObject;
        int min = snakeController.score - 2;
        if (min < 0) min = 1;
        value = Random.Range(min, snakeController.score + 10);
    }

    public void Delete()
    {
        Destroy(obs);
        Destroy(gameObject);
    }

}
