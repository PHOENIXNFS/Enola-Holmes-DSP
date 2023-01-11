using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PicturePuzzleTileTrigger : MonoBehaviour
{
    public Inventory_Canvas inventory_Canvas;
    public static bool IsPicturePuzzleTileObjectDestroyed;

    private void Awake()
    {
        if (IsPicturePuzzleTileObjectDestroyed == true)
            Destroy(this.gameObject);
        else
            IsPicturePuzzleTileObjectDestroyed = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            InventoryManager.inventoryManagerInstance.inventory.AddInventoryItem(new InventoryItem { inventoryItemType = InventoryItem.InventoryItemType.PuzzleTile});
            inventory_Canvas.UpdateInventorySlots();
            Destroy(this.gameObject);
            IsPicturePuzzleTileObjectDestroyed = true;
            Debug.Log("Last Picture Puzzle Tile Added to Inventory");
        }
    }
}
