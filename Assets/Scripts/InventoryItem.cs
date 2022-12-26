using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItem {

    public enum InventoryItemType
    {
        PicturePuzzle,
        MycroftBook,
        PuzzleTile,
        CryptexPuzzleBox,
        ChessBoardPuzzle,
        //SecretGlasses,

    }

    public InventoryItemType inventoryItemType;

    public Sprite GetInventoryItemSprite()
    {
        switch (inventoryItemType)
        {
            default:
            case InventoryItemType.PicturePuzzle: return InventoryItemSprites.itemSpritesInstance.PicturePuzzleSprite; 
            case InventoryItemType.MycroftBook: return InventoryItemSprites.itemSpritesInstance.MycroftBookSprite;
            case InventoryItemType.CryptexPuzzleBox: return InventoryItemSprites.itemSpritesInstance.CryptexPuzzleBoxSprite;
            case InventoryItemType.PuzzleTile: return InventoryItemSprites.itemSpritesInstance.PuzzleTileSprite;
            case InventoryItemType.ChessBoardPuzzle: return InventoryItemSprites.itemSpritesInstance.ChessBoardPuzzleSprite;
            //case InventoryItemType.SecretGlasses: return inventoryItemSprites.itemSpritesInstance.SecretGlassesSprite;
        }
    }

    public Button GetInventoryItemButton()
    {
        switch (inventoryItemType)
        {
            default:
            case InventoryItemType.PicturePuzzle: return InventoryItemSpriteButtons.itemSpriteButtonsInstance.PicturePuzzleSpriteButton;
            case InventoryItemType.CryptexPuzzleBox:   return InventoryItemSpriteButtons.itemSpriteButtonsInstance.CryptexPuzzleBoxSpriteButton;
            case InventoryItemType.MycroftBook: return InventoryItemSpriteButtons.itemSpriteButtonsInstance.MycroftBookSpriteButton;
            case InventoryItemType.PuzzleTile: return InventoryItemSpriteButtons.itemSpriteButtonsInstance.PuzzleTileSpriteButton;
            case InventoryItemType.ChessBoardPuzzle: return InventoryItemSpriteButtons.itemSpriteButtonsInstance.ChessBoardPuzzleButton;
            //case InventoryItemType.SecretGlasses: return InventoryItemSpriteButtons.itemSpriteButtonsInstance.SecretGlassesSpriteButton;
        }
    }

}
