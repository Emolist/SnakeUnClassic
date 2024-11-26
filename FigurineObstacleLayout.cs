using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FigurineObstacleLayout : MonoBehaviour
{
    public GameObject obstacle;
    public Image thisImage;

    private void Awake()
    {
        thisImage = this.gameObject.GetComponent<Image>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (obstacle != null)
        {
            transform.position = Camera.main.WorldToScreenPoint(obstacle.transform.position);
        } else Destroy(this.gameObject);
    }

    public void ChangeSprite(Sprite figure)
    {
        thisImage.sprite = figure;
    }
}
