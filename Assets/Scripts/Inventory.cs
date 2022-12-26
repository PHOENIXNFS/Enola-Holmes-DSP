using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Inventory
{
    public List<InventoryItem> inventoryItemList;

    public Inventory()
    {
        inventoryItemList = new List<InventoryItem>();

        AddInventoryItem(new InventoryItem { inventoryItemType = InventoryItem.InventoryItemType.PicturePuzzle });


        Debug.Log("No of items in inventory: " + inventoryItemList.Count);
    }

    public void AddInventoryItem(InventoryItem inventoryItem)
    {
        inventoryItemList.Add(inventoryItem);
    }

    public void RemoveInventoryItem(InventoryItem.InventoryItemType inventoryItemType)
    {
        inventoryItemList.RemoveAll(i => i.inventoryItemType == inventoryItemType);
    }

    public List<InventoryItem> GetInventoryItemList()
    {
        return inventoryItemList;
    }

}
