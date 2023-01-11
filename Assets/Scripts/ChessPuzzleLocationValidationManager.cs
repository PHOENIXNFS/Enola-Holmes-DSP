using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChessPuzzleLocationValidationManager : MonoBehaviour
{
    public bool bIsAllChessPiecesInPosition;
    public bool bIsChessPuzzleComplete;

    public BlackKingValidator BlackKingValidator;
    public BlackKnightValidator BlackKnightValidator;
    //public BlackPawnValidator BlackPawnValidator;
    public BlackQueenValidator BlackQueenValidator;
    public WhiteBishopValidator WhiteBishopValidator;
    public WhiteKnightValidator WhiteKnightValidator;
    public WhiteQueenValidator WhiteQueenValidator;
    public WhiteRookValidator WhiteRookValidator;
    public WhitePawnValidatorPosition1 WhitePawnValidatorPosition1;
    public WhitePawnValidatorPosition2 WhitePawnValidatorPosition2;
    //public WhitePawnValidatorPosition3 WhitePawnValidatorPosition3;

    public ReturnToMenu returnToMenu;

    public Inventory_Canvas inventory_Canvas;

    private void Awake()
    {
        bIsAllChessPiecesInPosition = false;
        inventory_Canvas = GameManager.gameManagerInstance.inventoryCanvas;
        returnToMenu = GameManager.gameManagerInstance.returnToMenu;
        bIsChessPuzzleComplete = false;
    }

    private void Start()
    {
        BlackKingValidator = FindObjectOfType<BlackKingValidator>();
        BlackKnightValidator = FindObjectOfType<BlackKnightValidator>();
        BlackQueenValidator = FindObjectOfType<BlackQueenValidator>();
        WhiteBishopValidator = FindObjectOfType<WhiteBishopValidator>();
        WhiteKnightValidator = FindObjectOfType<WhiteKnightValidator>();
        WhiteQueenValidator = FindObjectOfType<WhiteQueenValidator>();
        WhiteRookValidator = FindObjectOfType<WhiteRookValidator>();
        WhitePawnValidatorPosition1 = FindObjectOfType<WhitePawnValidatorPosition1>();
        WhitePawnValidatorPosition2 = FindObjectOfType<WhitePawnValidatorPosition2>();
    }

    private void Update()
    {
        StartCoroutine(GameComplete());
        ReturnToMainGame();
        
    }

    public void CheckChessPuzzleCompletion()
    {
        if(BlackKingValidator.bIsBlackKingInPosition == true &&
            BlackKnightValidator.bIsBlackKnightInPosition ==true &&
            //BlackPawnValidator.bIsBlackPawnInPosition == true &&
            BlackQueenValidator.bIsBlackQueenInPosition == true &&
            WhiteBishopValidator.bIsWhiteBishopInPosition == true &&
            WhiteKnightValidator.bIsWhiteKnightInPosition == true &&
            WhiteQueenValidator.bIsWhiteQueenInPosition == true &&
            WhiteRookValidator.bIsWhiteRookInPosition == true &&
            WhitePawnValidatorPosition1.bIsWhitePawnInPosition1 == true &&
            WhitePawnValidatorPosition2.bIsWhitePawnInPosition2 == true)
            //WhitePawnValidatorPosition3.bIsWhitePawnInPosition3 == true)
        {
            bIsAllChessPiecesInPosition = true;
        }
    }

    IEnumerator GameComplete()
    {
        if (bIsAllChessPiecesInPosition && !bIsChessPuzzleComplete)
        {
            bIsChessPuzzleComplete = true;
            yield return new WaitForSeconds(1);
            //SceneManager.LoadSceneAsync("TestLevel");
            returnToMenu.LoadGame();
            InventoryManager.inventoryManagerInstance.inventory.Inventory_Load_Data();
            //inventory_Canvas.UpdateInventorySlots();
            InventoryManager.inventoryManagerInstance.inventory.RemoveInventoryItem(InventoryItem.InventoryItemType.ChessBoardPuzzle);
            InventoryManager.inventoryManagerInstance.inventory.RemoveInventoryItem(InventoryItem.InventoryItemType.MycroftBook);
            inventory_Canvas.UpdateInventorySlots();
            GameScoreManager.gameScoreManagerInstance.GameScore += 100;
            GameScoreManager.gameScoreManagerInstance.GameScoreUpdated = true;
            //UnityEditor.EditorApplication.isPlaying = false;
            //SceneManager.UnloadSceneAsync("Chess Puzzle");
            GameManager.gameManagerInstance.UnloadScene("Chess Puzzle");
        }
        
    }

    private void ReturnToMainGame()
    {
        if (bIsAllChessPiecesInPosition == false)
        {
            if (Input.GetKey(KeyCode.Backspace))
            {
                //gameMenu.LoadScemeAsync();
                //SceneManager.LoadSceneAsync("TestLevel");
                returnToMenu.LoadGame();
                InventoryManager.inventoryManagerInstance.inventory.Inventory_Load_Data();
                inventory_Canvas.UpdateInventorySlots();
                //SceneManager.UnloadSceneAsync("Chess Puzzle");
                GameManager.gameManagerInstance.UnloadScene("Chess Puzzle");
            }
        }

    }
}
