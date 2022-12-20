using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory_Canvas : MonoBehaviour
{
    public Inventory inventory;
    public Transform inventorySlotMain;
    public Transform inventorySlotTemplate;

    private void Awake()
    {
        inventorySlotMain = transform.Find("InventorySlotMain");
        inventorySlotTemplate = inventorySlotMain.Find("InventorySlotTemplate");
    }

    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;
        UpdateInventorySlots();
    }

    public void UpdateInventorySlots()
    {
        int x = 0;
        int y = 0;
        float inventorySlotSize = 11.0f;
        foreach (InventoryItem item in inventory.GetInventoryItemList())
        {
            RectTransform inventorySlotRectangleTransform = Instantiate(inventorySlotTemplate, inventorySlotMain).GetComponent<RectTransform>();
            inventorySlotRectangleTransform.gameObject.SetActive(true);
            inventorySlotRectangleTransform.anchoredPosition = new Vector2(x * inventorySlotSize, y * inventorySlotSize);
            Image inventorySlotImage = inventorySlotRectangleTransform.Find("image").GetComponent<Image>();
            inventorySlotImage.sprite = item.GetInventoryItemSprite();

            x++;
            if (x >= 3)
            {
                x = 0;
                y++;

            }

        }
    }
}
