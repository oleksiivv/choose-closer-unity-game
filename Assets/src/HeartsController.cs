using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartsController : MonoBehaviour
{
    public DatabaseController db;

    public List<Image> hearts;

    private int heartsAmount;

    public void Start(){
        heartsAmount = db.GetHeartsAmount();

        ShowHearts();
    }

    public bool MinusHeart(){
        heartsAmount = heartsAmount > 0 ? heartsAmount-1 : heartsAmount;

        db.SetHeartsAmount(heartsAmount);
        ShowHearts();

        return heartsAmount>0;
    }

    public void ShowHearts(){
        HideAllHearts();

        heartsAmount = heartsAmount == 0 ? db.GetHeartsAmount() : heartsAmount;

        for(int i=0; i<heartsAmount; i++){
            hearts[i].gameObject.SetActive(true);
        }
    }

    private void HideAllHearts(){
        foreach(var heart in hearts){
            heart.gameObject.SetActive(false);
        }
    }
}
