using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UpgradeHolder : MonoBehaviour
{
    public List<UpgradeScript> upgrades = new List<UpgradeScript>();
    public float speed, spawnRate, multiplier;
    public int hp;
    public bool notLooseHp, plusCollect, hpDrop, customization, spikeEadible, tail;

    public GameObject customizationButton, playButton;

    private int speed2Lvl;

    private void Start()
    {
        if (PlayerPrefs.GetFloat("speed") > 0)
        {
            speed = PlayerPrefs.GetFloat("speed");
        }
        else speed = 2f;

        speed2Lvl = upgrades[2].currentLevel;

        hp = PlayerPrefs.GetInt("hp");
        multiplier = PlayerPrefs.GetFloat("mult");
        spawnRate = PlayerPrefs.GetFloat("spawnRate");


        if (PlayerPrefs.GetInt("custUpgrade") == 1)
        {
            customization = true;
        } else customization = false;

        if (PlayerPrefs.GetInt("tail") == 1)
        {
            tail = true;
        }
        else tail = false;
    }


    private void Update()
    {
        if (customization)
        {
            customizationButton.SetActive(true);
        } else customizationButton.SetActive(false);

        if (tail)
        {
            playButton.SetActive(true);
        }
        else playButton.SetActive(false);
    }

    public void SaveUpgrades()
    {
        for (int i = 0; i < upgrades.Count; i++)
        {
            if (upgrades[i].currentLevel > 0)
            {
                switch (upgrades[i].tag)
                {
                    case "Tail":
                        if (PlayerPrefs.GetInt("tail") != 1)
                        {
                            tail = true;
                            SaveInt("tail", 1);
                        }
                        break;
                    case "Customization":
                        if (PlayerPrefs.GetInt("custUpgrade") != 1)
                        {
                            customization = true;
                            SaveInt("custUpgrade", 1);
                        }
                        break;
                    case "Spike":
                        if (PlayerPrefs.GetInt("spikeUpgrade") != 1)
                        {
                            spikeEadible = true;
                            SaveInt("spikeUpgrade", 1);
                        }
                        break;
                    case "Speed1":
                        if (!upgrades[i].upgraded)
                        {
                            speed += 1f;
                        }
                        if (PlayerPrefs.GetFloat("speed") < speed)
                        {
                            PlayerPrefs.SetFloat("speed", speed);
                        }
                        break;
                    case "Speed3":
                        if (!upgrades[i].upgraded)
                        {
                            speed += 1.5f;
                        }
                        if (PlayerPrefs.GetFloat("speed") < speed)
                        {
                            PlayerPrefs.SetFloat("speed", speed);
                        }
                        break;
                    case "Loot1":
                        if (PlayerPrefs.GetInt("loot1Upgrade") != 1)
                        {
                            plusCollect = true;
                            SaveInt("loot1Upgrade", 1);
                        }
                        break;
                    case "Health2":
                        if (PlayerPrefs.GetInt("hp2Upgrade") != 1)
                        {
                            notLooseHp = true;
                            SaveInt("hp2Upgrade", 1);
                        }
                        break;
                    case "Health3":
                        if (PlayerPrefs.GetInt("hp3Upgrade") != 1)
                        {
                            hpDrop = true;
                            SaveInt("hp3Upgrade", 1);
                        }
                        break;
                    default:
                        {
                            switch (upgrades[i].tag)
                            {
                                case "Health1":
                                    hp = upgrades[i].currentLevel;
                                    if (PlayerPrefs.GetInt("hp") < hp)
                                    {
                                        PlayerPrefs.SetInt("hp", hp);
                                    }
                                    break;
                                case "Spawn1":
                                    if (upgrades[i].currentLevel == 1)
                                    {
                                        spawnRate = 1f;
                                        PlayerPrefs.SetFloat("spawnRate", spawnRate);
                                    }
                                    else if (upgrades[i].currentLevel == 2)
                                    {
                                        spawnRate = 0.7f;
                                        PlayerPrefs.SetFloat("spawnRate", spawnRate);
                                    }
                                    else if (upgrades[i].currentLevel == 3)
                                    {
                                        spawnRate = 0.4f;
                                        PlayerPrefs.SetFloat("spawnRate", spawnRate);
                                    }
                                    break;
                                case "Loot2":
                                    multiplier = 1 + (0.1f * upgrades[i].currentLevel);
                                    if (PlayerPrefs.GetFloat("mult") < multiplier)
                                    {
                                        PlayerPrefs.SetFloat("mult", multiplier);
                                    }
                                    break;
                            }
                        }
                        break;

                }
            }
        }
    }
    private void SaveInt(string key, int value)
    {
        PlayerPrefs.SetInt(key, value);
        PlayerPrefs.Save();
    }

    public void Speed2()
    {
        if (!upgrades[2].upgraded)
        {
            if (speed2Lvl < upgrades[2].currentLevel)
            {
                speed = PlayerPrefs.GetFloat("speed") + 0.5f;
                speed2Lvl = upgrades[2].currentLevel;
            }
            PlayerPrefs.SetFloat("speed", speed);
        }
    }
}
