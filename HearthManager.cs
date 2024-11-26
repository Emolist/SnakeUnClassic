using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class HearthManager : MonoBehaviour
{
    public int health;
    public TMP_Text hearth_count;
    public GameObject emptyHearth;
    public GameObject fullHearth;

    [SerializeField] private Collector collector;

    private void Start()
    {
        if(UpgradeLoader.hp == 0)
        {
            health = -1;
        } else health = UpgradeLoader.hp;
    }

    void Update()
    {
        if (health >= 0)
        {
            hearth_count.text = health.ToString();
        }

        if(health > 0)
        {
            emptyHearth.SetActive(false);
            fullHearth.SetActive(true);
        }

        if(health == 0)
        {
            emptyHearth.SetActive(true);
            fullHearth.SetActive(false);
        }

        if(health < 0)
        {
            emptyHearth.SetActive(false);
            fullHearth.SetActive(false);
            hearth_count.text = " ";
        }
    }

    public void HealthLose()
    {
        if (UpgradeLoader.notLooseHp)
        {
            float chance = Random.value;
            if(chance > 0.9f)
            {
                ;
            } else
            {
                if (health > 0)
                {
                    health -= 1;
                }else collector.lost = true;
            }
        }
        else
        {
            if (health > 0)
            {
                health -= 1;
            }
            else collector.lost = true;
        }
    }
    
    public void HealthGain()
    {
        if(health < 5)
        {
            health += 1;
        }
    }
}
