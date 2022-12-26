using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhitePawnValidatorPosition3 : MonoBehaviour
{
    public bool bIsWhitePawnInPosition3;
    public ChessPuzzleLocationValidationManager ChessPuzzleLocationValidationManager;

    private void Awake()
    {
        bIsWhitePawnInPosition3 = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("White Pawn"))
        {
            bIsWhitePawnInPosition3 = true;
            ChessPuzzleLocationValidationManager.CheckChessPuzzleCompletion();
            //Invoke(nameof(ChessPuzzleLocationValidationManager.CheckChessPuzzleCompletion), 0.5f);
        }
    }
}
