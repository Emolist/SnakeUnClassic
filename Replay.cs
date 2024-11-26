using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

public class Replay : MonoBehaviour
{
    public TotalScore total;
    public void Play()
    {
        YandexGame.FullscreenShow();
        YandexGame.NewLeaderboardScores("Total", total.score);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
