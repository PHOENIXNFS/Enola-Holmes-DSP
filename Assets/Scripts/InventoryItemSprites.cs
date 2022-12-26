using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItemSprites : MonoBehaviour
{
    public static InventoryItemSprites itemSpritesInstance { get; private set; }

    private void Start()
    {
        itemSpritesInstance = this;
    }

    public Sprite MycroftBookSprite;
    public Sprite PuzzleTileSprite;
    public Sprite CryptexPuzzleBoxSprite;
    public Sprite ChessBoardPuzzleSprite;
    //public Sprite SecretGlassesSprite;
    public Sprite PicturePuzzleSprite;

}
