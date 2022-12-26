using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessPuzzleLocationValidationManager : MonoBehaviour
{
    public bool bIsAllChessPiecesInPosition;

    public BlackKingValidator BlackKingValidator;
    public BlackKnightValidator BlackKnightValidator;
    public BlackPawnValidator BlackPawnValidator;
    public BlackQueenValidator BlackQueenValidator;
    public WhiteBishopValidator WhiteBishopValidator;
    public WhiteKnightValidator WhiteKnightValidator;
    public WhiteQueenValidator WhiteQueenValidator;
    public WhiteRookValidator WhiteRookValidator;
    public WhitePawnValidatorPosition1 WhitePawnValidatorPosition1;
    public WhitePawnValidatorPosition2 WhitePawnValidatorPosition2;
    public WhitePawnValidatorPosition3 WhitePawnValidatorPosition3;

    private void Awake()
    {
        bIsAllChessPiecesInPosition = false;
    }

    private void Update()
    {
        if (bIsAllChessPiecesInPosition)
        {
            //GameComplete();
            StartCoroutine(GameComplete());
        }
        
    }

    public void CheckChessPuzzleCompletion()
    {
        if(BlackKingValidator.bIsBlackKingInPosition == true &&
            BlackKnightValidator.bIsBlackKnightInPosition ==true &&
            BlackPawnValidator.bIsBlackPawnInPosition == true &&
            BlackQueenValidator.bIsBlackQueenInPosition == true &&
            WhiteBishopValidator.bIsWhiteBishopInPosition == true &&
            WhiteKnightValidator.bIsWhiteKnightInPosition == true &&
            WhiteQueenValidator.bIsWhiteQueenInPosition == true &&
            WhiteRookValidator.bIsWhiteRookInPosition == true &&
            WhitePawnValidatorPosition1.bIsWhitePawnInPosition1 == true &&
            WhitePawnValidatorPosition2.bIsWhitePawnInPosition2 == true &&
            WhitePawnValidatorPosition3.bIsWhitePawnInPosition3 == true)
        {
            bIsAllChessPiecesInPosition = true;
        }
    }

    IEnumerator GameComplete()
    {
        yield return new WaitForSeconds(1);
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
