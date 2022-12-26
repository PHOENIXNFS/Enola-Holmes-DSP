using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteQueenValidator : MonoBehaviour
{
    public bool bIsWhiteQueenInPosition;
    public ChessPuzzleLocationValidationManager ChessPuzzleLocationValidationManager;

    private void Awake()
    {
        bIsWhiteQueenInPosition = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("White Queen"))
        {
            bIsWhiteQueenInPosition = true;
            ChessPuzzleLocationValidationManager.CheckChessPuzzleCompletion();
            //Invoke(nameof(ChessPuzzleLocationValidationManager.CheckChessPuzzleCompletion), 0.5f);
        }
    }
}
