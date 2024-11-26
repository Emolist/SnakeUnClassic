using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starter : MonoBehaviour
{

    public GameObject playButton;

    private void Awake()
    {
        Time.timeScale = 0;
    }

    private void Start()
    {
        playButton.SetActive(true);
        Time.timeScale = 0;
    }

    public void Starting()
    {
        Time.timeScale = 1f;
        playButton.SetActive(false);
    }

}
