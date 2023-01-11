using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Newtonsoft.Json;

[System.Serializable]
public class Inventory
{
    public List<InventoryItem> inventoryItemList;
    public List<InventoryItem> tempInventoryLoadList;

    public Inventory()
    {
        inventoryItemList = new List<InventoryItem>();
        tempInventoryLoadList = new List<InventoryItem>();

        //AddInventoryItem(new InventoryItem { inventoryItemType = InventoryItem.InventoryItemType.MusicButton});
        //AddInventoryItem(new InventoryItem { inventoryItemType = InventoryItem.InventoryItemType.ChessBoardPuzzle });


        Debug.Log("No of items in inventory: " + inventoryItemList.Count);
    }

     public void AddInventoryItem(InventoryItem inventoryItem)
    {
        if(inventoryItemList.Find(i => i.inventoryItemType == inventoryItem.inventoryItemType) == null)
        {
            inventoryItemList.Add(inventoryItem);
        }
    }

    public void RemoveInventoryItem(InventoryItem.InventoryItemType inventoryItemType)
    {
        inventoryItemList.RemoveAll(i => i.inventoryItemType == inventoryItemType);
    }

    public List<InventoryItem> GetInventoryItemList()
    {
        Debug.Log(inventoryItemList.Count);
        return inventoryItemList;
    }

    public void Inventory_Save_Data()
    {
        //Debug.Log(inventoryItemList.Count);
        PlayerPrefs.SetString("SavedInventoryData", JsonUtility.ToJson(this));
        Debug.Log(PlayerPrefs.GetString("SavedInventoryData"));
        PlayerPrefs.Save();
    }

    public void Inventory_Load_Data()
    {
        
        Inventory loadedInventory = JsonUtility.FromJson<Inventory>(PlayerPrefs.GetString("SavedInventoryData"));
        this.inventoryItemList = loadedInventory.inventoryItemList;
        Debug.Log("Items in Loaded Inventory: " + inventoryItemList.Count); 
    }
     
}
