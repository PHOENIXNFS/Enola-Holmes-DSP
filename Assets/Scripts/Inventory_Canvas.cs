using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Inventory_Canvas : MonoBehaviour
{
    //public Inventory inventory;
    public Transform inventorySlotMain;
    public Transform inventorySlotTemplate;

    private List<InventoryItem> itemAddedToCanvas;
    private List<InventoryItem> checklistItemActuallyRetrieved;

    public Inventory_Canvas inventory_CanvasInstance { get; private set; }

    int xPosition = 0;
    float yPosition = 0;

    private void Awake()
    {

        if (inventory_CanvasInstance != null && inventory_CanvasInstance != this)
        {
            Destroy(gameObject);

        }
        else
        {
            inventory_CanvasInstance = this;
        }

        DontDestroyOnLoad(this.gameObject);

    }

    private void Start()
    {
        inventorySlotMain = transform.Find("InventorySlotMain");
        inventorySlotTemplate = inventorySlotMain.Find("InventorySlotTemplate");

        itemAddedToCanvas = new List<InventoryItem>();
    }

    //public void SetInventory(Inventory inventory)
    //{

    //    this.inventory = inventory;
    //    //inventory.Inventory_Load_Data();
    //    UpdateInventorySlots();
    //    //inventory.Inventory_Save_Data();
    //}

    public void UpdateInventorySlots()
    {
        Debug.LogFormat("<color=white>Update Inventory Slots</color>");
        float inventorySlotSize = 11.0f;
        Debug.LogFormat("<color=white>Inventory Slot Size Initiated</color>");
        if (itemAddedToCanvas == null) itemAddedToCanvas = new List<InventoryItem>();
        Debug.LogFormat("<color=white>ItemAddedtoCanvas List Initiated</color>");
        //checklistItemActuallyRetrieved = new List<InventoryItem>();
        checklistItemActuallyRetrieved = InventoryManager.inventoryManagerInstance.inventory.GetInventoryItemList();
        Debug.LogFormat("<color=red>Item Actually Retrieved from InventoryItem List {0}</color>", checklistItemActuallyRetrieved.Count); //returning 0

        xPosition = 0;
        yPosition = 0;
        //Remove items from canvas if not in inventory list
        //foreach(InventoryItem _item in itemAddedToCanvas)
        //{
        //    if(checklistItemActuallyRetrieved.Find(i => i.inventoryItemType == _item.inventoryItemType) == null)
        //    {
        //        //Remove item from canvas
        //        GameObject _itemToRemove = inventorySlotMain.Find(System.Enum.GetName(typeof(InventoryItem.InventoryItemType), _item.inventoryItemType)).gameObject;
        //        Destroy(_itemToRemove);

        //        _itemsToRemove.Add(_item);

        //        //xPosition--;
        //        //if(xPosition <= 0)
        //        //{
        //        //    xPosition = 2;
        //        //    yPosition -= 1.5f;
        //        //}
        //    }
        //}
        foreach(Transform child in inventorySlotMain)
        {
            if(!child.name.Equals("InventorySlotTemplate"))
                Destroy(child.gameObject);
        }
        itemAddedToCanvas = new List<InventoryItem>();

        //itemAddedToCanvas.RemoveAll(i => _itemsToRemove.Contains(i));

        foreach (InventoryItem item in checklistItemActuallyRetrieved) //not entering loop when switching scene back to level//
        {
            Debug.LogFormat("<color=white>Inside Update Slot Inventory Loop - 1</color>");
            if (itemAddedToCanvas.Find(i => i.inventoryItemType == item.inventoryItemType) == null)
            {
                Debug.LogFormat("<color=white>Inside Update Slot Inventory Loop - 2</color>");
                RectTransform inventorySlotRectangleTransform = Instantiate(inventorySlotTemplate, inventorySlotMain).GetComponent<RectTransform>();
                inventorySlotRectangleTransform.gameObject.name = System.Enum.GetName(typeof(InventoryItem.InventoryItemType), item.inventoryItemType);
                inventorySlotRectangleTransform.gameObject.SetActive(true);
                inventorySlotRectangleTransform.anchoredPosition = new Vector2(xPosition * inventorySlotSize, -yPosition * inventorySlotSize);

                Image inventorySlotImage = inventorySlotRectangleTransform.Find("image").GetComponent<Image>();
                inventorySlotImage.sprite = item.GetInventoryItemSprite();

                //Button inventorySlotButton = inventorySlotRectangleTransform.GetComponentInChildren<Button>(true);
                GameObject inventorySlotButtonObj = item.GetInventoryItemButton().gameObject;
                GameObject inventorySlotButtonInst = Instantiate(inventorySlotButtonObj, inventorySlotRectangleTransform.GetChild(0));

                itemAddedToCanvas.Add(item);

                Debug.LogFormat("<color=green>Adding item {0}</color>", item.inventoryItemType);

                xPosition++;
                if (xPosition >= 3)
                {
                    xPosition = 0;
                    yPosition += 1.5f;

                }

            }
            
        }
    }
}
