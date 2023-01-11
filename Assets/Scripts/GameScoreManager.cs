using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScoreManager : MonoBehaviour
{
    public int GameScore;
    public bool GameScoreUpdated;
    public Inventory_Canvas inventory_Canvas;
    public bool bIsMusicButtonAdded;

    public static GameScoreManager gameScoreManagerInstance { get; private set; }

    private void Awake()
    {
        if (gameScoreManagerInstance != null && gameScoreManagerInstance != this)
        {
            Destroy(gameObject);

        }
        else
        {
            gameScoreManagerInstance = this;
        }
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        if (GameScoreUpdated == true)
        {
            return;
        }
        else
        {
            GameScore = 0;
            GameScoreUpdated = false;
            bIsMusicButtonAdded = false;
        }
        GameScoreUpdated = false;
        inventory_Canvas = GameManager.gameManagerInstance.inventoryCanvas;

    }

    private void Update()
    {
        //Debug.Log("Score is: " + GameScore);
        AddMusicButton();
    }

    public void AddMusicButton()
    {
        if(GameScore >= 100 && bIsMusicButtonAdded == false)
        {
            bIsMusicButtonAdded = true;
            InventoryManager.inventoryManagerInstance.inventory.AddInventoryItem(new InventoryItem { inventoryItemType = InventoryItem.InventoryItemType.MusicButton });
            inventory_Canvas.UpdateInventorySlots();

        }
    }
}
