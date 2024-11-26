using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToPlay : MonoBehaviour
{
    public void GoPlay()
    {
        SceneManager.LoadScene("MainScene");
    }
}
