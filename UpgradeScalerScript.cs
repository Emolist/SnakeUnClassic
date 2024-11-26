using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpgradeScalerScript : MonoBehaviour
{
    public TMP_Text valueText;
    public GameObject Cost;
    public int baseCost, costAddPerLvl;

    private UpgradeScript Upgrade;
    private int currentLvl;
    public int currentCost;

    private void Start()
    {
        Upgrade = this.gameObject.GetComponent<UpgradeScript>();
        currentLvl = Upgrade.currentLevel;
    }
    private void Update()
    {
        currentLvl = Upgrade.currentLevel;
        currentCost = baseCost + (costAddPerLvl * currentLvl);
        Upgrade.value = currentCost;
        valueText.text = currentCost.ToString();

        if (Upgrade.upgraded)
        {
            Cost.SetActive(false);
        } else Cost.SetActive(true);
    }
}
