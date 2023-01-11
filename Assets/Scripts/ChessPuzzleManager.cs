using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessPuzzleManager : MonoBehaviour
{
    public List<ChessBoardTileSelector> ChessBoardTiles = new List<ChessBoardTileSelector>();
    public ChessPuzzleSpriteMoveOnMouseClick currentlySelectedChessPiece;

    public Vector3 HeightAdjustment;

    public void Start()
    {
        HeightAdjustment = new Vector3(0, 0.5f, 0);
        currentlySelectedChessPiece = FindObjectOfType<ChessPuzzleSpriteMoveOnMouseClick>();
    }

    public void CheckTileForPositionofSpriteMovement()
    {
        if (Input.GetMouseButtonDown(1) && currentlySelectedChessPiece != null && currentlySelectedChessPiece.IsChessPieceSelected)
        {
            RaycastHit HitChessTile;
            Ray hitray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(hitray, out HitChessTile, Mathf.Infinity))
            {
                //foreach (ChessBoardTileSelector chesstile in ChessBoardTiles)
                //{
                //    if (HitChessTile.point == chesstile.transform.position)
                //    {
                //        ChessPuzzleSpriteMoveOnMouseClick.TargetPosition = chesstile.transform.position;
                //    }
                //}

                //if(hitray)
                foreach(ChessBoardTileSelector chessTile in ChessBoardTiles)
                {
                    if( HitChessTile.collider.gameObject.name == chessTile.gameObject.name)
                    {
                        currentlySelectedChessPiece.TargetPosition = chessTile.transform.position;
                        currentlySelectedChessPiece.TargetPosition += HeightAdjustment;
                    }
                }    
            }
        }
    }
}
