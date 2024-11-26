using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using UnityEngine;

public class ObstacleText : MonoBehaviour
{
    public GameObject obstacle;
    TMP_Text text;

    private void Start()
    {
        text = this.gameObject.GetComponent<TMP_Text>();
    }

    void Update()
    {
        transform.position = Camera.main.WorldToScreenPoint(obstacle.transform.position);
        text.text = obstacle.GetComponent<Obstacle>().value.ToString();

    }
}
