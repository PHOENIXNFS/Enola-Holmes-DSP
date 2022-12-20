using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryButton : MonoBehaviour
{
    public GameObject InventoryCanvas;

    private void Awake()
    {
        InventoryCanvas.SetActive(false);
    }

    public void OpenInventory()
    {
        if(InventoryCanvas != null)
        {
            bool IsInventoryActive = InventoryCanvas.activeSelf;
            InventoryCanvas.SetActive(!IsInventoryActive);
        }
    }
}
