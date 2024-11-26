using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopPlayLayout : MonoBehaviour
{
    public GameObject stopPlayButton, mainShopButton;

    void Update()
    {
        if (mainShopButton.activeInHierarchy)
        {
            stopPlayButton.SetActive(false);
        } else stopPlayButton.SetActive(true);
    }
}
