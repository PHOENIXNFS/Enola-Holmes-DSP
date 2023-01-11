using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MycroftBookButtonVisibility : MonoBehaviour
{
    private Vector3 originalScale;
    
    private void Awake()
    {
        originalScale = transform.localScale;
        transform.localScale = Vector3.zero;
    }

    private void Update()
    {
        if(InventoryManager.inventoryManagerInstance.IsMycroftBookInInventory)
        {
            transform.localScale = originalScale;
        }
    }


}
