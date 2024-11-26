using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public bool stoping;

    private void Start()
    {
        stoping = false;
    }
    public void ChangeScene()
    {
        SceneManager.LoadScene("Shop");
    }

    public void StopPlay()
    {
        Collector collector = GameObject.FindGameObjectWithTag("Collector").GetComponent<Collector>();
        stoping = true;
        collector.lost = true;
        ChangeScene();
    }
}
