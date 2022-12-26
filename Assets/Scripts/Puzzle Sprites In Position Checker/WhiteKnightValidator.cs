using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteKnightValidator : MonoBehaviour
{
    public bool bIsWhiteKnightInPosition;
    public ChessPuzzleLocationValidationManager ChessPuzzleLocationValidationManager;

    private void Awake()
    {
        bIsWhiteKnightInPosition = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("White Knight"))
        {
            bIsWhiteKnightInPosition = true;
            ChessPuzzleLocationValidationManager.CheckChessPuzzleCompletion();
            //Invoke(nameof(ChessPuzzleLocationValidationManager.CheckChessPuzzleCompletion), 0.5f);
        }
    }
}
