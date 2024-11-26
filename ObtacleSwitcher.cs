using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class ObtacleSwitcher : MonoBehaviour
{
    private List<FigurineObstacles> obstacles;
    private bool passed = false;

    private void Start()
    {
        obstacles = new List<FigurineObstacles>();
        obstacles.AddRange(this.gameObject.GetComponentsInChildren<FigurineObstacles>());
    }
    void Update()
    {
        for (int i = 0; i < obstacles.Count; i++)
        {
            if (obstacles[i] == null)
            {
                obstacles.RemoveAt(i);
                passed = true;
            }
        }

        if (passed)
        {
            foreach (var obstacle in obstacles)
            {
                GameObject go = obstacle.gameObject;
                go.GetComponent<SpriteRenderer>().color = Color.gray;
                go.GetComponent<BoxCollider2D>().isTrigger = false;
            }
        }
    }
}
