using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;
using UnityEngine.Audio;


public class InventoryButtonFunctionality : MonoBehaviour
{
    public ReturnToMenu returnToMenu;
    //public GameMenu gameMenu;
    public GameObject inventory_Canvas;
    //public static bool IsFinalTileInInventory;
    //public static bool IsMycroftBookInInventory;
    //public AudioClip ChangedMusic;
    //public AudioSource PlayerSource;
    public AudioClip ChangedMusic;
    public GameAudioManager gameAudioManager;

    private void Start()
    {
        inventory_Canvas = FindObjectOfType<Inventory_Canvas>().gameObject;
        InventoryManager.inventoryManagerInstance.IsFinalTileInInventory = false;
        InventoryManager.inventoryManagerInstance.IsMycroftBookInInventory = false;
        returnToMenu = FindObjectOfType<ReturnToMenu>();
        gameAudioManager = FindObjectOfType<GameAudioManager>();
        //gameMenu = FindObjectOfType<GameMenu>();
    }

    public void PicturePuzzleButton()
    {
        InventoryManager.inventoryManagerInstance.IsFinalTileInInventory = InventoryManager.inventoryManagerInstance.inventory.inventoryItemList
            .Find(x => x.inventoryItemType == InventoryItem.InventoryItemType.PuzzleTile) != null;


        Debug.Log(InventoryManager.inventoryManagerInstance.IsFinalTileInInventory);
        //returnToMenu.SaveScene();
        returnToMenu.SaveGame();
        InventoryManager.inventoryManagerInstance.inventory.Inventory_Save_Data();

        //SceneManager.LoadSceneAsync("Puzzle");
        //SceneManager.UnloadSceneAsync("TestLevel");
        GameManager.gameManagerInstance.LoadScene("Puzzle");
        //inventory_Canvas.SetActive(false);
 
    }

    public void ChessPuzzleButton()
    {
        InventoryManager.inventoryManagerInstance.IsMycroftBookInInventory = InventoryManager.inventoryManagerInstance.inventory.inventoryItemList
            .Find(x => x.inventoryItemType == InventoryItem.InventoryItemType.MycroftBook) != null;


        Debug.Log(InventoryManager.inventoryManagerInstance.IsMycroftBookInInventory);
        //returnToMenu.SaveScene();
        returnToMenu.SaveGame();
        InventoryManager.inventoryManagerInstance.inventory.Inventory_Save_Data();

        //SceneManager.LoadSceneAsync("Chess Puzzle");
        //SceneManager.UnloadSceneAsync("TestLevel");
        //inventory_Canvas.SetActive(false);
        GameManager.gameManagerInstance.LoadScene("Chess Puzzle");
    }

    public void MusicChangeButton()
    {
        //if(PlayerSource.isPlaying)
        //{
        //    PlayerSource.Stop();
        //    PlayerSource.PlayOneShot(ChangedMusic);
        //}
        if(gameAudioManager.GetComponent<AudioSource>().isPlaying)
        {
            gameAudioManager.GetComponent<AudioSource>().Stop();
            gameAudioManager.GetComponent<AudioSource>().clip = ChangedMusic;
            gameAudioManager.GetComponent<AudioSource>().Play();
            gameAudioManager.GetComponent<AudioSource>().loop = true;

            InventoryManager.inventoryManagerInstance.inventory.RemoveInventoryItem(InventoryItem.InventoryItemType.MusicButton);
            inventory_Canvas.GetComponent<Inventory_Canvas>().UpdateInventorySlots();
        }
        
    }
}
