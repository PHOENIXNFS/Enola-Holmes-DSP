using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalTile : MonoBehaviour
{
    //public InventoryButtonFunctionality inventoryButtonFunctionality;
    private Vector3 originalScale;
    
    private void Awake()
    {
        originalScale = transform.localScale;
        transform.localScale = Vector3.zero;
        //this.gameObject.SetActive(false);
        //inventoryButtonFunctionality = FindObjectOfType<InventoryButtonFunctionality>();
    }

    private void Update()
    {
        if (InventoryManager.inventoryManagerInstance.IsFinalTileInInventory)
            ChangeFinalTileVisibility();
    }

    public void ChangeFinalTileVisibility()
    {
        transform.localScale = originalScale;
    }
}
