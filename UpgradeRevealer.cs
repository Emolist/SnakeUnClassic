using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeRevealer : MonoBehaviour
{
    public GameObject nextUpgrade, nextFirstLvlUpgrade;
    public bool externalProperties;
    public UpgradeScript additional;

    UpgradeScript thisUpgrade;

    private void Start()
    {
        thisUpgrade = this.gameObject.GetComponent<UpgradeScript>();
    }

    private void Update()
    {
        if (nextUpgrade != null)
        {
            if (thisUpgrade.upgraded && !externalProperties)
            {
                nextUpgrade.SetActive(true);
            }
        }

        if (nextFirstLvlUpgrade != null)
        {
            if (thisUpgrade.currentLevel >= 1)
            {
                nextFirstLvlUpgrade.SetActive(true);
            }
        }

        if (externalProperties)
        {
            if(additional.upgraded && thisUpgrade.upgraded)
            {
                nextUpgrade.SetActive(true);
            }
        }
    }
}
