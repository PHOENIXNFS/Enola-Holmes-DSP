using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemSpriteButtons : MonoBehaviour
{
    public static InventoryItemSpriteButtons itemSpriteButtonsInstance { get; private set; }

    private void Awake()
    {
        itemSpriteButtonsInstance = this;
    }

    public Button MycroftBookSpriteButton;
    public Button PuzzleTileSpriteButton;
    public Button CryptexPuzzleBoxSpriteButton;
    public Button PicturePuzzleSpriteButton;
    public Button ChessBoardPuzzleButton;
    //public Button SecretGlassesSpriteButton;

}
