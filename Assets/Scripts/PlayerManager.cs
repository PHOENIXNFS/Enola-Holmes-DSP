using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public Inventory inventory;
    public Inventory_Canvas inventory_Canvas;

    private void Start()
    {
        inventory = new Inventory();
        inventory_Canvas.SetInventory(inventory);
    }

}
