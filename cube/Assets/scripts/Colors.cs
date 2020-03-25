using System;
using UnityEngine;

public class Colors
{
    public readonly Color color;
    public float possibleCountOfSameColor;

    public Colors(Color color, float num) {
        this.color = color;
        this.possibleCountOfSameColor = num;
    }
}
