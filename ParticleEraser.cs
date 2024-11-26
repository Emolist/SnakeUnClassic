using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEraser : MonoBehaviour
{
    private float timer = 1.5f;
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
