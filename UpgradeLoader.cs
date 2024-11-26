using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeLoader : MonoBehaviour
{
    public static UpgradeLoader Instance { get; private set; }
    public static float speed, spawnRate, multiplier;
    public static int hp;
    public static bool notLooseHp, plusCollect, hpDrop, spikeEadible;


    void Awake()
    {
        speed = PlayerPrefs.GetFloat("speed", 2f);
        multiplier = PlayerPrefs.GetFloat("mult", 1f);
        spawnRate = PlayerPrefs.GetFloat("spawnRate", 1.5f);

        hp = PlayerPrefs.GetInt("hp", 0);

        if (PlayerPrefs.GetInt("spikeUpgrade") == 1)
        {
            spikeEadible = true;
        }
        else spikeEadible = false;

        if (PlayerPrefs.GetInt("loot1Upgrade") == 1)
        {
            plusCollect = true;
        } else plusCollect = false;

        if (PlayerPrefs.GetInt("hp2Upgrade") == 1)
        {
            notLooseHp = true;
        }else notLooseHp = false;

        if (PlayerPrefs.GetInt("hp3Upgrade") == 1)
        {
            hpDrop = true;
        }else hpDrop = false;
    }
}
