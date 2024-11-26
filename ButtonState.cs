using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonState : MonoBehaviour
{
    public Image buttonTargetImage;
    public Sprite normalButtonTargetImage, pressedButtonTargetImage;

    public bool pressed;

    private void Start()
    {
        pressed = false;
    }

    private void Update()
    {
        if (pressed)
        {
            buttonTargetImage.sprite = pressedButtonTargetImage;
        } else buttonTargetImage.sprite = normalButtonTargetImage;
    }

    public void Pressing()
    {
        if (pressed)
        {
            pressed = false;
        } else pressed = true;
    }
}
