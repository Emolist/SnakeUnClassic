using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PeachHolder : MonoBehaviour
{
    public TMP_Text peachCounter;
    public int numberOfPeaches;

    private void Start()
    {
        numberOfPeaches = PlayerPrefs.GetInt("peaches");
    }

    void Update()
    {
        peachCounter.text = numberOfPeaches.ToString();
    }

    public void SavePeaches(int increment)
    {
        numberOfPeaches += increment;
        PlayerPrefs.SetInt("peaches", numberOfPeaches);
    }

    public bool CheckIfEnough(int value)
    {
        if (numberOfPeaches < value)
        {
            return false;
        }
        else return true;
    }

    public void SpendPeaches(int decrement)
    {
        numberOfPeaches -= decrement;
        PlayerPrefs.SetInt("peaches", numberOfPeaches);
    }
}
