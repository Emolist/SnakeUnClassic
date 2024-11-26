using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Bank : MonoBehaviour
{
    public List<int> bank = new List<int>(5);

    private void Awake()
    {
        bank[0] = PlayerPrefs.GetInt("bank0", 0);
        bank[1] = PlayerPrefs.GetInt("bank1", 0);
        bank[2] = PlayerPrefs.GetInt("bank2", 0);
        bank[3] = PlayerPrefs.GetInt("bank3", 0);
        bank[4] = PlayerPrefs.GetInt("bank4", 0);
    }

    public void Add(List<int> adder)
    {
        for (int i = 0; i < adder.Count; i++)
        {
            bank[i] += adder[i];
        }

        Save();
    }

    public void Add(int index, int value)
    {
        bank[index] += value;
        Save();
    }

    public void Spend(int index, int value)
    {
            bank[index] -= value;
            Save();
    }

    public bool CheckIfEnough(int index, int value)
    {
        if (bank[index] < value)
        {
            return false;
        }
        else return true;
    }

    private void Save()
    {
        PlayerPrefs.SetInt("bank0", bank[0]);
        PlayerPrefs.SetInt("bank1", bank[1]);
        PlayerPrefs.SetInt("bank2", bank[2]);
        PlayerPrefs.SetInt("bank3", bank[3]);
        PlayerPrefs.SetInt("bank4", bank[4]);

        PlayerPrefs.Save();
    }

}
