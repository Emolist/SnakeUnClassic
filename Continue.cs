using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Continue : MonoBehaviour
{
    public GameObject continueButton;

    public void Starting()
    {
        Time.timeScale = 1f;
        continueButton.SetActive(false);
    }
}
