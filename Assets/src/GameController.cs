using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public List<LevelData> levels;

    public DatabaseController db;

    public SpriteRenderer questionImageSlot;

    public List<SpriteRenderer> variants;

    public HeartsController heartsController;

    public Text actualAreaText;

    public List<Text> areaVariants;

    [HideInInspector()]
    public int currentLevel;

    public List<Text> levelLabels;

    public ParticleSystem winEffect, loseHeartEffect, gameOverEffect;

    private bool levelIsCompleted = false;

    private int numberOfCalls = 0;

    private bool clicked=false;

    public GameObject startPanel;

    public GameObject levelIntroPanel;

    public VariantsPositionsRandomizer variantsPositionsRandomizer;

    public SlotsColorsController slotsColors;

    public GameObject levelsCompletedPanel;

    private void Awake() {
        Time.timeScale=1;
        startPanel.SetActive(true);

        currentLevel = db.GetCurrentLevel();

        ShowLevel();
    }

    private void ShowLevel(){
        if(currentLevel>=levels.Count){
            levelsCompletedPanel.SetActive(true);
            return;
        }

        levelsCompletedPanel.SetActive(false);

        levelIntroPanel.SetActive(true);
        Invoke(nameof(HideIntroPanel), 2.5f);

        foreach (var levelLabel in levelLabels) {
            levelLabel.text = "Level " + (currentLevel+1).ToString();
        }

        questionImageSlot.GetComponent<SpriteRenderer>().sprite = levels[currentLevel].questionFigure;

        actualAreaText.text = ""; //levels[currentLevel].actualArea.ToString();

        for(int i=0; i<variants.Count; i++){
            variants[i].GetComponent<SpriteRenderer>().sprite = levels[currentLevel].variantsFigures[i];

            areaVariants[i].text = "";//levels[currentLevel].areaVariants[i].ToString();

            //resetting box collider
            Destroy(variants[i].gameObject.GetComponent<BoxCollider2D>());
            variants[i].gameObject.AddComponent<BoxCollider2D>();
        }

        heartsController.ShowHearts();

        clicked=false;
        numberOfCalls=0;
        levelIsCompleted=false;

        variantsPositionsRandomizer.RandomizeSlots();
        slotsColors.ShowColor();
    }

    public void HideIntroPanel(){
        levelIntroPanel.SetActive(false);

        startPanel.SetActive(false);
    }

    public void Answer(int id){
        if(clicked || Time.timeScale==0){
            return;
        }

        clicked=true;
        int correctVariant = levels[currentLevel].GetCorrectAnswerId();

        if (id==correctVariant) {
            Debug.Log("level completed");
            if(currentLevel<levels.Count){
                StopAllCoroutines();
                StartCoroutine(TextCounter(actualAreaText, levels[currentLevel].actualArea, 0.0075f));

                for(int i=0; i<levels[currentLevel].areaVariants.Count; i++){
                    StartCoroutine(TextCounter(areaVariants[i], levels[currentLevel].areaVariants[i], 0.0075f));
                }
                
                currentLevel++;
                db.SaveCurrentLevel(currentLevel);
                Invoke(nameof(LevelComplete), 2f * levels[currentLevel].actualArea / 90);
            }
            else{
                //TODO: show win panel
            }
        } else {
            if(!heartsController.MinusHeart()){
                GameOver();
            } else {
                loseHeartEffect.Play();
            }

            clicked=false;
        }
    }

    public void LevelComplete(){
        if (!levelIsCompleted) {
            Invoke(nameof(LevelComplete), 0.25f);

            return;
        }

        winEffect.Play();

        ShowLevel();
    }

    public void GameOver(){
        db.ResetLevel();
        db.ResetHearts();

        heartsController.Start();
        
        currentLevel = db.GetCurrentLevel();
        ShowLevel();

        gameOverEffect.Play();
    }

    IEnumerator TextCounter(Text text, int n, float speed){
        int cnt = 0;
        while(cnt < n){
            cnt++;
            text.text = cnt.ToString();

            yield return new WaitForSeconds(speed);
        }

        numberOfCalls++;

        if (currentLevel >= levels.Count || (numberOfCalls == (levels[currentLevel].variantsFigures.Count + 1))) {
            Invoke(nameof(setLevelIsCompletedAsTrue), 0.25f);

            numberOfCalls = 0;
        }
    }

    private void setLevelIsCompletedAsTrue(){
        levelIsCompleted = true;
    }
}
