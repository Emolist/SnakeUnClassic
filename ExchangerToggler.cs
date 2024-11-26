using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExchangerToggler : MonoBehaviour
{
    public List<GameObject> fruits = new List<GameObject>();
    public List<GameObject> backs = new List<GameObject>();
    public GameObject activeFruit;

    public int index;

    void Update()
    {
        for (int i = 0; i < fruits.Count; i++)
        {
            if (activeFruit != null)
            {
                if (activeFruit != fruits[i])
                {
                    backs[i].SetActive(false);
                }
                else backs[i].SetActive(true);
            } else backs[i].SetActive(false);
        }
    }

    public void SetActive(GameObject fruit)
    {
        for (int y = 0;y < fruits.Count; y++)
        {
            if (fruits[y] == fruit)
            {
                index = y;
                break;
            }
        }

        if (activeFruit != fruit)
        {
            activeFruit = fruit;
        }

        if (activeFruit == fruit)
        {
            if (backs[index].activeInHierarchy)
            {
                backs[index].SetActive(false);
                activeFruit = null;
                index = -1;
            }
        }
    }
}
