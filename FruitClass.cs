using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FruitClass : MonoBehaviour
{
    public int Value;
    public ParticleSystem particles;

    public void Delete()
    {
        if (particles != null)
        {
            Instantiate(particles, this.gameObject.transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}
