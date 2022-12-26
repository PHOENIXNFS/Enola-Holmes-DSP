using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JournalButton : MonoBehaviour
{
    public GameObject JournalCanvas;

    private void Awake()
    {
        JournalCanvas.SetActive(false);
    }

    public void OpenJournal()
    {
        if (JournalCanvas != null)
        {
            bool IsInventoryActive = JournalCanvas.activeSelf;
            JournalCanvas.SetActive(!IsInventoryActive);
        }
    }
}
