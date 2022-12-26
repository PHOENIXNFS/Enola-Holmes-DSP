using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackKingValidator : MonoBehaviour
{
    public bool bIsBlackKingInPosition;
    public ChessPuzzleLocationValidationManager ChessPuzzleLocationValidationManager;

    private void Awake()
    {
        bIsBlackKingInPosition = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Black King"))
        {
            bIsBlackKingInPosition = true;
            //Debug.Log("Is Black King In Position: " + bIsBlackKingInPosition);
            ChessPuzzleLocationValidationManager.CheckChessPuzzleCompletion();
            //Invoke(nameof(ChessPuzzleLocationValidationManager.CheckChessPuzzleCompletion), 0.5f);
        }
    }
}
