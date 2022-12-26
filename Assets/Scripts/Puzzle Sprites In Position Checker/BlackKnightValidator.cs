using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackKnightValidator : MonoBehaviour
{
    public bool bIsBlackKnightInPosition;
    public ChessPuzzleLocationValidationManager ChessPuzzleLocationValidationManager;

    private void Awake()
    {
        bIsBlackKnightInPosition = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Black Knight"))
        {
            bIsBlackKnightInPosition = true;
            ChessPuzzleLocationValidationManager.CheckChessPuzzleCompletion();
            //Invoke(nameof(ChessPuzzleLocationValidationManager.CheckChessPuzzleCompletion), 0.5f);
        }
    }
}
