using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuzzleManager : MonoBehaviour
{
    [SerializeField] private Transform PuzzleBox;
    [SerializeField] private Transform PuzzlePiece;

    public GameMenu gameMenu;
    public ReturnToMenu returnToMenu;
    public Inventory inventory;

    public SlidingPuzzleTileMovement SlidingPuzzleTileMovement;
    public Puzzle puzzle;

    public bool bIsPuzzleComplete;

    private int emptylocation;
    private int size;

    private void Start()
    {
        //size = 4;
        //CreatePuzzlePieces(0.1f);
        bIsPuzzleComplete = false;
    }

    private void Update()
    {
        //GameComplete();
        //ReturnToMainGame();
    }

    private void CreatePuzzlePieces(float GapThickness)
    {
        float width = 1 / (float)size;
        for (int row = 0; row < size; row++)
        {
            for (int column = 0; column < size; column++)
            {
                Transform piece = Instantiate(PuzzlePiece, PuzzleBox);
                piece.localPosition = new Vector3(-1 + (2 * width * column) + width,
                                                   +1 - (2 * width * column) - width,
                                                   0);
                piece.localScale = ((2 * width) - GapThickness) * Vector3.one;
                piece.name = $"{(row * size) + column}";
                if ((row == size - 1) && (column == size - 1))
                {
                    emptylocation = (size * size) - 1;
                    piece.gameObject.SetActive(false);
                }
            }
        }
           
    }

    public void GameComplete()
    {
        
        if (SlidingPuzzleTileMovement.bIsFinalTileInPosition == true && puzzle.bisAllTilesInPosition == true)
        {
            bIsPuzzleComplete = true;
            //Cutscene Puzzle Solved;
            //Cutscene Puzzle Box Found;
            //remove sliding puzzle and puzzle tile from inventory;
            inventory.RemoveInventoryItem(InventoryItem.InventoryItemType.PicturePuzzle);            
            inventory.AddInventoryItem(new InventoryItem { inventoryItemType = InventoryItem.InventoryItemType.CryptexPuzzleBox});
            gameMenu.LoadScemeAsync();
            returnToMenu.LoadGame();
            SceneManager.UnloadSceneAsync("Puzzle");
            //UnityEditor.EditorApplication.isPlaying = false;
        }
    }

    private void ReturnToMainGame()
    {
        while (bIsPuzzleComplete == false)
        {
            if (Input.GetKey(KeyCode.Backspace))
            {
                gameMenu.LoadScemeAsync();
                returnToMenu.LoadGame();


                SceneManager.UnloadSceneAsync("Puzzle");

            }
        }
        
    }
}
