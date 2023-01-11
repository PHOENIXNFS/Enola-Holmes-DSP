using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public Inventory inventory;
    public Inventory_Canvas Inventory_Canvas;
    public bool IsFinalTileInInventory;
    public bool IsMycroftBookInInventory;

    public static InventoryManager inventoryManagerInstance { get; private set; }

    private void Awake()
    {
        if(inventoryManagerInstance != null && inventoryManagerInstance != this)
        {
            Destroy(gameObject);

        }
        else
        {
            inventoryManagerInstance = this;
        }
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
    }

    public void SetInventory(Inventory inventory)
    {

        this.inventory = inventory;
        Inventory_Canvas.UpdateInventorySlots();
    }

}
