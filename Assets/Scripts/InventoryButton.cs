using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryButton : MonoBehaviour
{
    public GameObject InventoryCanvas;
    public Vector3 OriginalScale;
    public Vector3 ReducedScale;
    public bool bIsInventorycanvasOpen;

    private void Awake()
    {
        //InventoryCanvas.SetActive(false);
        OriginalScale = InventoryCanvas.transform.localScale;
        ReducedScale = Vector3.zero;
        InventoryCanvas.transform.localScale = Vector3.zero;
        bIsInventorycanvasOpen = false;


    }

    public void OpenInventory()
    {
        //if (InventoryCanvas != null)
        //{
        //    bool IsInventoryActive = InventoryCanvas.activeSelf;
        //    InventoryCanvas.SetActive(!IsInventoryActive);
        //}


        //if (InventoryCanvas.transform.localScale == OriginalScale /*&& InventoryCanvas != null*/)
        //{
        //    //Debug.Log("Boolean Value: " + bIsInventorycanvasOpen);
        //    InventoryCanvas.transform.localScale = ReducedScale;
        //    //bIsInventorycanvasOpen = false;
        //}

        //if (InventoryCanvas.transform.localScale == ReducedScale /*&& InventoryCanvas != null*/)
        //{
        //    //Debug.Log("Boolean Value: " + bIsInventorycanvasOpen);
        //    InventoryCanvas.transform.localScale = OriginalScale;
        //    //bIsInventorycanvasOpen = true;
        //}
        bIsInventorycanvasOpen = !bIsInventorycanvasOpen;
        InventoryCanvas.transform.localScale = bIsInventorycanvasOpen ? OriginalScale : ReducedScale;

    }
}
