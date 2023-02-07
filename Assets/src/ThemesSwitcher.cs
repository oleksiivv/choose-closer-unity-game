using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThemesSwitcher : MonoBehaviour
{
    public List<Image> themes;

    public Color32 activeColor, defaultColor;

    void Start(){
        UpdateState();
    }

    public void Choose(int id){
        PlayerPrefs.SetInt("theme", id);

        UpdateState();
    }

    public void UpdateState(){
        hideAll();

        themes[PlayerPrefs.GetInt("theme", 0)].GetComponent<Image>().color = activeColor;
    }

    void hideAll(){
        foreach (var item in themes)
        {
            item.GetComponent<Image>().color = defaultColor;
        }
    }
}
