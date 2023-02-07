using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public GameObject buttonMutedSound, buttonNormalSound;

    public AudioController audioController;

    public ParticleSystem progressDeletedSuccessfully;

    void Start()
    {
        if(PlayerPrefs.GetInt("!sound")==0){

            buttonMutedSound.SetActive(false);
            buttonNormalSound.SetActive(true);

        }
        else{
            buttonMutedSound.SetActive(true);
            buttonNormalSound.SetActive(false);
        }

        audioController.Notify();
    }

    public void muteSound(){
        PlayerPrefs.SetInt("!sound",1);
        buttonMutedSound.SetActive(true);
        buttonNormalSound.SetActive(false);
        
        audioController.Notify();
    }

    public void unmuteSound(){
        PlayerPrefs.SetInt("!sound",0);
        buttonMutedSound.SetActive(false);
        buttonNormalSound.SetActive(true);

        audioController.Notify();
    }

    public GameObject undoProgressPanel;

    public void showUndoProgressPanel(){
        undoProgressPanel.SetActive(true);
    }


    public void undoProgress(){
        PlayerPrefs.DeleteAll();
        
        undoProgressPanel.SetActive(false);
        Start();

        progressDeletedSuccessfully.Play();
    }

    public void cancelUndoProgress(){
        undoProgressPanel.SetActive(false);
    }
}
