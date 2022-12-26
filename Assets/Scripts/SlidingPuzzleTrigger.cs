using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingPuzzleTrigger : MonoBehaviour
{
    public Inventory inventory;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //inventory.AddInventoryItem(new InventoryItem { inventoryItemType = InventoryItem.InventoryItemType.PicturePuzzle });
            Destroy(this.gameObject);
            Debug.Log("Picture Puzzle Added to Inventory");
        }
    }
}
