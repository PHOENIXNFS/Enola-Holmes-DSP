using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class ChessBoardTileSelector : MonoBehaviour
{
    
    public ChessPuzzleSpriteMoveOnMouseClick ChessPuzzleSpriteMoveOnMouseClick;
    [HideInInspector] public Material originalMaterial;
    public Material HighlightedMaterial;

    private void Start()
    {
        originalMaterial = GetComponent<MeshRenderer>().material;
    }

    public void CheckTileForPositionofSpriteMovement()
    {
        if (Input.GetMouseButtonDown(1) && ChessPuzzleSpriteMoveOnMouseClick.IsChessPieceSelected)
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
            }
        }
    }

    private void OnMouseEnter()
    {
        GetComponent<MeshRenderer>().material = HighlightedMaterial;
    }

    private void OnMouseExit()
    {
        GetComponent<MeshRenderer>().material = originalMaterial;
    }

}
