using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteRookValidator : MonoBehaviour
{
    public bool bIsWhiteRookInPosition;
    public ChessPuzzleLocationValidationManager ChessPuzzleLocationValidationManager;

    private void Awake()
    {
        bIsWhiteRookInPosition = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("White Rook"))
        {
            bIsWhiteRookInPosition = true;
            ChessPuzzleLocationValidationManager.CheckChessPuzzleCompletion();
            //Invoke(nameof(ChessPuzzleLocationValidationManager.CheckChessPuzzleCompletion), 0.5f);
        }
    }
}
