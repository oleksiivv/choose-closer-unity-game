using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Theming : MonoBehaviour
{
    public SpriteRenderer bgImage;

    public List<Image> themes;

    void Start(){
        bgImage.sprite = themes[PlayerPrefs.GetInt("theme")].sprite;
        bgImage.color = themes[PlayerPrefs.GetInt("theme")].color;
    }
}
