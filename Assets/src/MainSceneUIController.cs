using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainSceneUIController : ScenesManager
{
    public GameObject pausePanel;

    public GameObject confirmRestartPanel;

    public GameController gameController;

    public GameObject levelsCompletedPanel;

    public void LevelsCompletedPanelSetActive(bool active){
        levelsCompletedPanel.SetActive(active);
    }

    public void Pause(){
        Time.timeScale=0;
        pausePanel.SetActive(true);
    }

    public void Resume(){
        Time.timeScale=1;
        pausePanel.SetActive(false);
    }

    public void Restart(){
        confirmRestartPanel.SetActive(true);
    }

    public void CancelRestart(){
        confirmRestartPanel.SetActive(false);
    }

    public void ConfirmRestart(){
        Time.timeScale=1;
        
        pausePanel.SetActive(false);
        confirmRestartPanel.SetActive(false);
        
        gameController.GameOver();
    }
}
