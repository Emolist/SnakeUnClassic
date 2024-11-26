using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeScript : MonoBehaviour
{
    public int index;
    public int value;
    public int maxLevel, currentLevel;
    public bool upgraded;

    Bank bank;


    void Start()
    {
        bank = GameObject.FindGameObjectWithTag("Bank").GetComponent<Bank>();
        
        currentLevel = PlayerPrefs.GetInt(this.gameObject.name + "lvl", 0);

        if (currentLevel == maxLevel)
        {
            upgraded = true;
        }
    }

    public void Upgrade()
    {
        if (bank.CheckIfEnough(index, value))
        {
            bank.Spend(index, value);
            currentLevel += 1;
            PlayerPrefs.SetInt(this.gameObject.name + "lvl", currentLevel);
            PlayerPrefs.Save();
        }
        else Debug.Log("Not enough of" + index);
    }

    void Update()
    {
        if(currentLevel == maxLevel)
        {
            upgraded = true;
        }

        if (upgraded)
        {
            this.gameObject.GetComponent<Button>().interactable = false;
        }
    }
}
