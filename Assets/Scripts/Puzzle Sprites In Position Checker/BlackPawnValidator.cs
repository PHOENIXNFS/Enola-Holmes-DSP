using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackPawnValidator : MonoBehaviour
{
    public bool bIsBlackPawnInPosition;
    public ChessPuzzleLocationValidationManager ChessPuzzleLocationValidationManager;

    private void Awake()
    {
        bIsBlackPawnInPosition = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Black Pawn"))
        {
            bIsBlackPawnInPosition = true;
            ChessPuzzleLocationValidationManager.CheckChessPuzzleCompletion();
            //Invoke(nameof(ChessPuzzleLocationValidationManager.CheckChessPuzzleCompletion), 0.5f);

        }
    }
}
