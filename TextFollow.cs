using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextFollow : MonoBehaviour
{
    public GameObject player;
    TMP_Text text;

    private void Start()
    {
        text = this.gameObject.GetComponent<TMP_Text>();
    }

    void Update()
    {
        transform.position = Camera.main.WorldToScreenPoint(player.transform.position) + new Vector3(-15,20,0);

        text.text = player.GetComponent<SnakeController>().score.ToString();

    }
}
