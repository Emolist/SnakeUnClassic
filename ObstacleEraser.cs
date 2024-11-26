using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleEraser : MonoBehaviour
{
    private float timer = 20f;
    private bool created = false;

    void Start()
    {
        created = true;
    }

    private void Update()
    {
        if (created)
        {
            timer -= Time.deltaTime;
        }

        if(timer < 0)
        {
            Destroy(this.gameObject);
        }
    }

}
