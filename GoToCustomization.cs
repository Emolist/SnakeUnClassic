using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToCustomization : MonoBehaviour
{
    public GameObject UpgradeShop, CustomizationShop;

    public void GoToCustom()
    {
        UpgradeShop.SetActive(false);
        CustomizationShop.SetActive(true);
    }
    public void GoToUpgrade()
    {
        UpgradeShop.SetActive(true);
        CustomizationShop.SetActive(false);
    }
}
