using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalTileFinishPoint : MonoBehaviour
{
    public bool bIsFinalTileInPosition;

    private void Awake()
    {
        bIsFinalTileInPosition = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<FinalTile>()) 
        {
            bIsFinalTileInPosition = true;
            Debug.Log(bIsFinalTileInPosition);
        }
    }
}
