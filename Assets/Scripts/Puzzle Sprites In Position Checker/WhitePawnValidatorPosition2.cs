using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhitePawnValidatorPosition2 : MonoBehaviour
{
    public bool bIsWhitePawnInPosition2;
    public ChessPuzzleLocationValidationManager ChessPuzzleLocationValidationManager;

    private void Awake()
    {
        bIsWhitePawnInPosition2 = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("White Pawn"))
        {
            bIsWhitePawnInPosition2 = true;
            ChessPuzzleLocationValidationManager.CheckChessPuzzleCompletion();
            //Invoke(nameof(ChessPuzzleLocationValidationManager.CheckChessPuzzleCompletion), 0.5f);
        }
    }
}
