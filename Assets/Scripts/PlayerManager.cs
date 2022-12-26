using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public Inventory inventory;
    public Inventory_Canvas inventory_Canvas;

    private void Start()
    {
        StartCoroutine(DelayedStart(0.1f));
    }

    private IEnumerator DelayedStart(float _delay)
    {
        yield return new WaitForSeconds(_delay);
        inventory = new Inventory();
        inventory_Canvas.SetInventory(inventory);
    }

}
