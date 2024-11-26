using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public static Score Instance { get; private set; }

    public static int totalScore;
    public TotalScore total;
    
    void Update()
    {
        if (total.score < 5)
        {
            totalScore = total.score;
        }
        else totalScore = 5;
    }
}
