using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhitePawnValidatorPosition1 : MonoBehaviour
{
    public bool bIsWhitePawnInPosition1;
    public ChessPuzzleLocationValidationManager ChessPuzzleLocationValidationManager;

    private void Awake()
    {
        bIsWhitePawnInPosition1 = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("White Pawn"))
        {
            bIsWhitePawnInPosition1 = true;
            ChessPuzzleLocationValidationManager.CheckChessPuzzleCompletion();
            //Invoke(nameof(ChessPuzzleLocationValidationManager.CheckChessPuzzleCompletion), 0.5f);
        }
    }
}
