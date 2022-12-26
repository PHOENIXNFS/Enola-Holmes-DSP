using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackQueenValidator : MonoBehaviour
{
    public bool bIsBlackQueenInPosition;
    public ChessPuzzleLocationValidationManager ChessPuzzleLocationValidationManager;

    private void Awake()
    {
        bIsBlackQueenInPosition = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Black Queen"))
        {
            bIsBlackQueenInPosition = true;
            ChessPuzzleLocationValidationManager.CheckChessPuzzleCompletion();
            //Invoke(nameof(ChessPuzzleLocationValidationManager.CheckChessPuzzleCompletion), 0.5f);
        }
    }
}
