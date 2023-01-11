using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SlidingPuzzleTrigger : MonoBehaviour
{
    //public Inventory inventory;
    public Inventory_Canvas inventory_Canvas;
    public static bool IsSlidingPuzzleObjectDestroyed;

    //public Texture2D EyeCursorTexture;
    //public CursorMode cursorMode = CursorMode.Auto;
    //public Vector2 cursorHotspot = Vector2.zero;


    private void Awake()
    {
        if (IsSlidingPuzzleObjectDestroyed == true)
            Destroy(this.gameObject);
        else
            IsSlidingPuzzleObjectDestroyed = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //inventory.AddInventoryItem(new InventoryItem { inventoryItemType = InventoryItem.InventoryItemType.PicturePuzzle });
            InventoryManager.inventoryManagerInstance.inventory.AddInventoryItem(new InventoryItem { inventoryItemType = InventoryItem.InventoryItemType.PicturePuzzle });
            inventory_Canvas.UpdateInventorySlots();
            Destroy(this.gameObject);
            IsSlidingPuzzleObjectDestroyed = true;
            Debug.Log("Picture Puzzle Added to Inventory");
        }

        //if(other.CompareTag("Player"))
        //{
        //    Cursor.SetCursor(EyeCursorTexture, cursorHotspot, cursorMode);
        //}
    }

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        Cursor.SetCursor(null, Vector2.zero, cursorMode);
    //    }
    //}
}
