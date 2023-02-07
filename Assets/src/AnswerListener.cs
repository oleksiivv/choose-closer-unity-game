using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerListener : MonoBehaviour
{
    public int id;

    public GameController gameController;

    private void OnMouseDown() {
        gameController.Answer(id);
    }
}
