using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotsColorsController : MonoBehaviour
{
    public List<SpriteRenderer> slots;

    public List<Color32> colors;

    private int lastShowedColor = -1;

    public void ShowColor() {
        int colorIndex = GetRandomColorIndex(lastShowedColor);

        lastShowedColor = colorIndex;

        foreach(var slot in slots){
            slot.color = colors[colorIndex];
        }
    }

    private int GetRandomColorIndex(int lastShowedColor){
        int index = Random.Range(0, colors.Count);

        return index != lastShowedColor
            ? index
            : GetRandomColorIndex(lastShowedColor);
    }
}
