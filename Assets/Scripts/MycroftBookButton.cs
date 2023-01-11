using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MycroftBookButton : MonoBehaviour
{
    public GameObject MycroftBookCanvas;

    private void Awake()
    {
        MycroftBookCanvas.SetActive(false);
    }

    public void OpenMycroftBook()
    {
        if (MycroftBookCanvas != null)
        {
            bool IsInventoryActive = MycroftBookCanvas.activeSelf;
            MycroftBookCanvas.SetActive(!IsInventoryActive);
        }
    }
}
