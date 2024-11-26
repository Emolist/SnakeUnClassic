using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Collector : MonoBehaviour
{
    public TMP_Text watermelon, lemon, blueberry, orange, apple;
    public List<int> Count;
    public bool lost;
    public Bank bank;
    [SerializeField] private HearthManager healthScript;

    private bool addToBank = false;
    private bool singleAdder = true;

    private float multiply;

    void Start()
    {
        Count.AddRange(new int[5]);
        multiply = UpgradeLoader.multiplier;
    }

    void Update()
    {
        orange.text = Count[0].ToString();
        blueberry.text = Count[1].ToString();
        lemon.text = Count[2].ToString();
        apple.text = Count[3].ToString();
        watermelon.text = Count[4].ToString();

        for (int n = 0; n < Count.Count; n++)
        {
            if (Count[n] < 0)
            {
                Count[n] = 0;
            }
        }

        if (lost)
        {
            addToBank = true;
        }

        if (addToBank && singleAdder)
        {
            if(multiply > 1f)
            {
                for(int c = 0; c < Count.Count; c++)
                {

                    Count[c] = Mathf.FloorToInt(Count[c] * multiply);
                }
            }
            bank.Add(Count);
            addToBank = false;
            singleAdder = false;
        }
        
    }

    public void Collect(int Value)
    {
        Value = Value - 1;
        if (UpgradeLoader.plusCollect)
        {
            Count[Value] += 2;
        }else Count[Value] += 1;
    }

    public void Lose(int index, int value)
    {
        Count[index] -= value;

        foreach (int i in Count)
        {
            if (i < 0)
            {
                healthScript.HealthLose();
                break;
            }
        }
    }
    public void Lose()
    {
        healthScript.HealthLose();
    }

    public void GainHealth()
    {
        healthScript.HealthGain();
    }
}
