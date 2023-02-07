using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VariantsPositionsRandomizer : MonoBehaviour
{
    public List<GameObject> variants;

    public List<Text> areas;

    private List<Vector3> variantsPositions;
    private List<Vector3> areasPositions;

    public void RandomizeSlots(){
        variantsPositions = new List<Vector3>();
        areasPositions = new List<Vector3>();

        for(int i=0; i<variants.Count; i++){
            variantsPositions.Add(variants[i].transform.position);
            areasPositions.Add(areas[i].transform.position);
        }

        for(int i=0; i<variants.Count; i++){
            int index = Random.Range(0, variantsPositions.Count);

            Vector3 variantPostition = variantsPositions[index];
            Vector3 areaPosition = areasPositions[index];

            variants[i].transform.position = variantPostition;
            areas[i].transform.position = areaPosition;

            variantsPositions.Remove(variantPostition);
            areasPositions.Remove(areaPosition);
        }
    }
}
