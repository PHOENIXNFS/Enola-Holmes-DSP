using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteBishopValidator : MonoBehaviour
{
    public bool bIsWhiteBishopInPosition;
    public ChessPuzzleLocationValidationManager ChessPuzzleLocationValidationManager;

    private void Awake()
    {
        bIsWhiteBishopInPosition = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("White Bishop"))
        {
            bIsWhiteBishopInPosition = true;
            ChessPuzzleLocationValidationManager.CheckChessPuzzleCompletion();
            //Invoke(nameof(ChessPuzzleLocationValidationManager.CheckChessPuzzleCompletion), 0.5f);
        }
    }
}
