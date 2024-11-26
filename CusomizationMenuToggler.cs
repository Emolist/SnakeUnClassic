using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CusomizationMenuToggler : MonoBehaviour
{
    public ButtonState controlButton;
    public GameObject menu;

    public List<ButtonState> buttons = new List<ButtonState>();

    private void Update()
    {
        if (controlButton.pressed  && menu != null && controlButton != null)
        {
            menu.SetActive(true);
        } else menu.SetActive(false);

        for(int i=0; i<buttons.Count; i++)
        {
            if (buttons[i].pressed)
            {
                ButtonState state = buttons[i];
                buttons.RemoveAt(i);
                foreach(ButtonState button in buttons)
                {
                    button.pressed = false;
                }
                buttons.Add(state);
            }
        }
    }
}
