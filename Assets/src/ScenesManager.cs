using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScenesManager : MonoBehaviour
{
    [SerializeField]
    private GameObject loadingPanel;

    public Slider loadingSlider;

    IEnumerator loadAsync(int id)
    {
        AsyncOperation operation = Application.LoadLevelAsync(id);
        loadingPanel.SetActive(true);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            loadingSlider.value = progress;
            Debug.Log(progress);
            yield return null;

        }
    }

    public void openScene(int id){
        //Time.timeScale = 1;
        loadingPanel.SetActive(true);
        StartCoroutine(loadAsync(id));
        //Application.LoadLevel(id);
    }

    public static void openSceneStatic(int id){
        Application.LoadLevel(id);
    }
}
