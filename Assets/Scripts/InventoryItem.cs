using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem {

    public InventoryItemSprites inventoryItemSprites;
    public enum InventoryItemType
    {
        PicturePuzzle,
        MycroftBook,
        PuzzleTile,
        PuzzleBox,
        //SecretGlasses,

    }

    public InventoryItemType inventoryItemType;

    public Sprite GetInventoryItemSprite()
    {
        switch (inventoryItemType)
        {
            default:
            case InventoryItemType.PicturePuzzle: return inventoryItemSprites.itemSpritesInstance.PicturePuzzleSprite; 
            case InventoryItemType.MycroftBook: return inventoryItemSprites.itemSpritesInstance.MycroftBookSprite;
            case InventoryItemType.PuzzleBox: return inventoryItemSprites.itemSpritesInstance.PuzzleBoxSprite;
            case InventoryItemType.PuzzleTile: return inventoryItemSprites.itemSpritesInstance.PuzzleTileSprite;
            //case InventoryItemType.SecretGlasses: return inventoryItemSprites.itemSpritesInstance.SecretGlassesSprite;
        }
    }

}
