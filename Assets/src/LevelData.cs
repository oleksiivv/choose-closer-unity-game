using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelData : MonoBehaviour
{
    [SerializeField]
    private int correctAnswerId {get{
        return this.GetCloser();
    }}

    public List<Sprite> variantsFigures;

    public Sprite questionFigure;

    public int actualArea;

    public List<int> areaVariants;

    public int GetCorrectAnswerId(){
        return this.correctAnswerId;
    }

    private int GetCloser(){
        int diff = Mathf.Abs(actualArea - areaVariants[0]);
        int id = 0;

        foreach(var area in areaVariants){
            int current = Mathf.Abs(actualArea - area);

            if (current < diff){
                diff = current;
                id = areaVariants.IndexOf(area);
            }
        }

        return id;
    }
}
