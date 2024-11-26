using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteHolder : MonoBehaviour
{
    public Sprite[] targets = new Sprite[5];

    public Sprite FigureReturn(int figure)
    {
        return targets[figure];
    }
}
