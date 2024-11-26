using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deleter : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other != null)
        {
            if (other.tag == "Obstacle")
            {
                other.GetComponent<Obstacle>().Delete();
            }
            else Destroy(other.gameObject);
        }
    }
}
