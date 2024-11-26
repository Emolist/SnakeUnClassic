using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeLvlLayout : MonoBehaviour
{
    public TMP_Text textOnButton;
    public string bufferText, multiplyBufferText;
    public bool multiplier;

    private string resultText;

    UpgradeScript Upgrade;

    private void Start()
    {
        Upgrade = this.gameObject.GetComponent<UpgradeScript>();
        bufferText = textOnButton.text;
        multiplyBufferText = textOnButton.text;
    }

    private void Update()
    {
        /*if (multiplier)
        {
            switch (Upgrade.currentLevel)
            {
                case 1:
                    bufferText = bufferText +" x1,1";
                    break;
                case 2:
                    bufferText = bufferText + " x1,2";
                    break;
                case 3:
                    bufferText = bufferText + " x1,3";
                    break;
                case 4:
                    bufferText = bufferText + " x1,4";
                    break;
                case 5:
                    bufferText = "Multiply total results x1,5";
                    break;
                case 6:
                    bufferText = "Multiply total results x1,6";
                    break;
                case 7:
                    bufferText = "Multiply total results x1,7";
                    break;
                case 8:
                    bufferText = "Multiply total results x1,8";
                    break;
                case 9:
                    bufferText = "Multiply total results x1,9";
                    break;
                case 10:
                    bufferText = "Multiply total results x2";
                    break;
                default:
                    bufferText = "Multiply total results";
                    break;
            }
        }*/
        resultText = bufferText + "     " + "(" + Upgrade.currentLevel.ToString() + "/" + Upgrade.maxLevel.ToString() + ")";
        textOnButton.text = resultText;
    }

    public void ChangeText()
    {
        switch (Upgrade.currentLevel)
        {
            case 1:
                bufferText = multiplyBufferText + " x1,1";
                break;
            case 2:
                bufferText = multiplyBufferText + " x1,2";
                break;
            case 3:
                bufferText = multiplyBufferText + " x1,3";
                break;
            case 4:
                bufferText = multiplyBufferText + " x1,4";
                break;
            case 5:
                bufferText = multiplyBufferText + " x1,5";
                break;
            case 6:
                bufferText = multiplyBufferText + " x1,6";
                break;
            case 7:
                bufferText = multiplyBufferText + " x1,7";
                break;
            case 8:
                bufferText = multiplyBufferText + " x1,8";
                break;
            case 9:
                bufferText = multiplyBufferText + " x1,9";
                break;
            case 10:
                bufferText = multiplyBufferText + " x2";
                break;
            default:
                bufferText = multiplyBufferText;
                break;
        }
    }
}
