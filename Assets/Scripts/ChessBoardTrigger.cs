using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessBoardTrigger : MonoBehaviour
{
    public Inventory_Canvas inventory_Canvas;
    public static bool IsChessPuzzleObjectDestroyed;

    private void Awake()
    {
        if (IsChessPuzzleObjectDestroyed == true)
            Destroy(this.gameObject);
        else
           IsChessPuzzleObjectDestroyed = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            InventoryManager.inventoryManagerInstance.inventory.AddInventoryItem(new InventoryItem { inventoryItemType = InventoryItem.InventoryItemType.ChessBoardPuzzle});
            inventory_Canvas.UpdateInventorySlots();
            Destroy(this.gameObject);
            IsChessPuzzleObjectDestroyed = true;
            Debug.Log("Chess Board Puzzle Added to Inventory");
        }
    }
}
