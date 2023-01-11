using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class PuzzleManager : MonoBehaviour
{
    [SerializeField] private Transform PuzzleBox;
    [SerializeField] private Transform PuzzlePiece;

    //public GameMenu gameMenu;
    public ReturnToMenu returnToMenu;
    //public Inventory inventory;
    public Inventory_Canvas inventory_Canvas;

    public SlidingPuzzleTileMovement SlidingPuzzleTileMovement;
    public Puzzle puzzle;

    public bool bIsPuzzleComplete;

    public GameObject PuzzleSolvedVideoPlayer;
    

    private int emptylocation;
    private int size;

    private void Start()
    {
        //size = 4;
        //CreatePuzzlePieces(0.1f);
        inventory_Canvas = GameManager.gameManagerInstance.inventoryCanvas;
        returnToMenu = GameManager.gameManagerInstance.returnToMenu;
        bIsPuzzleComplete = false;
        PuzzleSolvedVideoPlayer.gameObject.SetActive(false);
    }

    private void Update()
    {
        StartCoroutine(GameComplete());
        //GameComplete();
        ReturnToMainGame();
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

    public IEnumerator GameComplete()
    {
        
        if (SlidingPuzzleTileMovement.bIsFinalTileInPosition == true && puzzle.bisAllTilesInPosition == true && !bIsPuzzleComplete)
        {
            bIsPuzzleComplete = true;
            //Cutscene Puzzle Solved;
            //Cutscene Puzzle Box Found;
            //remove sliding puzzle and puzzle tile from inventory;
            //gameMenu.LoadScemeAsync();
            PuzzleSolvedVideoPlayer.gameObject.SetActive(true);
            PuzzleSolvedVideoPlayer.GetComponent<VideoPlayer>().Play();
            yield return new WaitForSeconds(5);
            //SceneManager.LoadSceneAsync("TestLevel");
            returnToMenu.LoadGame();
            InventoryManager.inventoryManagerInstance.inventory.Inventory_Load_Data(); //Data not loading
            //inventory_Canvas.UpdateInventorySlots();
            //inventory.RemoveInventoryItem(InventoryItem.InventoryItemType.PuzzleTile);
            InventoryManager.inventoryManagerInstance.inventory.RemoveInventoryItem(InventoryItem.InventoryItemType.PicturePuzzle);
            InventoryManager.inventoryManagerInstance.inventory.RemoveInventoryItem(InventoryItem.InventoryItemType.PuzzleTile);
            InventoryManager.inventoryManagerInstance.inventory.AddInventoryItem(new InventoryItem { inventoryItemType = InventoryItem.InventoryItemType.CryptexPuzzleBox });
            inventory_Canvas.UpdateInventorySlots();
            GameScoreManager.gameScoreManagerInstance.GameScore += 100;
            GameScoreManager.gameScoreManagerInstance.GameScoreUpdated = true;
            //UnityEditor.EditorApplication.isPlaying = false;
            //SceneManager.UnloadSceneAsync("Puzzle");
            GameManager.gameManagerInstance.UnloadScene("Puzzle");

        }
    }

    private void ReturnToMainGame()
    {
        if (bIsPuzzleComplete == false)
        {
            if (Input.GetKey(KeyCode.Backspace))
            {
                //gameMenu.LoadScemeAsync();               
                //SceneManager.LoadSceneAsync("TestLevel");
                returnToMenu.LoadGame();
                InventoryManager.inventoryManagerInstance.inventory.Inventory_Load_Data();
                // Debug.Log(InventoryManager.inventoryManagerInstance.inventory.inventoryItemList);
                inventory_Canvas.UpdateInventorySlots();
                //SceneManager.UnloadSceneAsync("Puzzle");
                GameManager.gameManagerInstance.UnloadScene("Puzzle");


            }
        }
        
    }
}
