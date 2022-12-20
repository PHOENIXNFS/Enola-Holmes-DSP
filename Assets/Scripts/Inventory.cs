using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    public List<InventoryItem> inventoryItemList;

    public Inventory()
    {
        inventoryItemList = new List<InventoryItem>();

        AddInventoryItem(new InventoryItem { inventoryItemType = InventoryItem.InventoryItemType.PicturePuzzle });
        AddInventoryItem(new InventoryItem { inventoryItemType = InventoryItem.InventoryItemType.PicturePuzzle });
        AddInventoryItem(new InventoryItem { inventoryItemType = InventoryItem.InventoryItemType.PicturePuzzle });
        AddInventoryItem(new InventoryItem { inventoryItemType = InventoryItem.InventoryItemType.PicturePuzzle });


        Debug.Log("No of items in inventory: " + inventoryItemList.Count);
    }

    public void AddInventoryItem(InventoryItem inventoryItem)
    {
        inventoryItemList.Add(inventoryItem);
    }

    public List<InventoryItem> GetInventoryItemList()
    {
        return inventoryItemList;
    }

}
