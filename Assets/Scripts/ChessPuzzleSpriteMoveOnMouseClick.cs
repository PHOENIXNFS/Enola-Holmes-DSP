using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessPuzzleSpriteMoveOnMouseClick : MonoBehaviour
{

    public static List<ChessPuzzleSpriteMoveOnMouseClick> ChessPiecesOnPaper = new List<ChessPuzzleSpriteMoveOnMouseClick>();
    //public ChessBoardTileSelector chessBoardTileSelector;
    public ChessPuzzleManager ChessPuzzleManager;
    public float MoveSpeed = 3.0f;
    public float RotationSpeed = 2.0f;
    public Vector3 TargetPosition;
    public Quaternion InitialRotation;
    public bool IsChessPieceSelected;

    private void Start()
    {
        ChessPiecesOnPaper.Add(this);
        TargetPosition = transform.position;
        InitialRotation = transform.rotation;

        //chessBoardTileSelector = FindObjectOfType<ChessBoardTileSelector>();
        ChessPuzzleManager = FindObjectOfType<ChessPuzzleManager>();
    }

    private void Update()
    {
        //if (Input.GetMouseButtonDown(1) && IsChessPieceSelected)
        //{
        //    RaycastHit hitchesstile;
        //    Ray hitray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //    if (Physics.Raycast(hitray, out hitchesstile, Mathf.Infinity))
        //    {
        //        TargetPosition = hitchesstile.point;
        //    }

        //    TargetPosition.y += 3.0f;

        //}

        ChessPuzzleManager.CheckTileForPositionofSpriteMovement();
        transform.position = Vector3.MoveTowards(transform.position, TargetPosition, MoveSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Slerp(InitialRotation, Quaternion.Euler(0, 0, 0), RotationSpeed * Time.deltaTime);
    }

    private void OnMouseDown()
    {
        IsChessPieceSelected = true;
        gameObject.GetComponent<SpriteRenderer>().color = Color.green;
        ChessPuzzleManager.currentlySelectedChessPiece = this;

        foreach(ChessPuzzleSpriteMoveOnMouseClick chessPiece in ChessPiecesOnPaper)
        {
            if(chessPiece != this)
            {
                chessPiece.IsChessPieceSelected = false;
                chessPiece.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            }
        }
    }
}
