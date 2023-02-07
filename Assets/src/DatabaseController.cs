using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatabaseController : MonoBehaviour
{
    public void SaveCurrentLevel(int level){
        PlayerPrefs.SetInt("current_level", level);
    }

    public int GetCurrentLevel(){
        return PlayerPrefs.GetInt("current_level", 0);
    }

    public void ResetLevel(){
        SaveCurrentLevel(0);
    }

    public void SetHeartsAmount(int heartsAmount){
        PlayerPrefs.SetInt("hearts-amount", heartsAmount);
    }

    public int GetHeartsAmount(){
        return PlayerPrefs.GetInt("hearts-amount", 3);
    }

    public void ResetHearts(){
        SetHeartsAmount(3);
    }
}
