using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MycroftBookTrigger : MonoBehaviour
{
    public Inventory_Canvas inventory_Canvas;
    public static bool IsMycroftBookObjectDestroyed;

    private void Awake()
    {
        if (IsMycroftBookObjectDestroyed == true)
            Destroy(this.gameObject);
        else
            IsMycroftBookObjectDestroyed = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            InventoryManager.inventoryManagerInstance.inventory.AddInventoryItem(new InventoryItem { inventoryItemType = InventoryItem.InventoryItemType.MycroftBook});
            inventory_Canvas.UpdateInventorySlots();
            Destroy(this.gameObject);
            IsMycroftBookObjectDestroyed = true;
            Debug.Log("Mycroft Book Puzzle Added to Inventory");
        }
    }
}
