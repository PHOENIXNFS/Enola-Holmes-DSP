using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessBoardTrigger : MonoBehaviour
{
    public Inventory inventory;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //inventory.AddInventoryItem(new InventoryItem { inventoryItemType = InventoryItem.InventoryItemType.ChessBoardPuzzle });
            Destroy(this.gameObject);
            Debug.Log("Chess Board Puzzle Added to Inventory");
        }
    }
}
