using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingPuzzleTileMovement : MonoBehaviour
{
    public float MoveSpeed = 3.0f;
    [HideInInspector] public Vector3 TargetPosition;
    [HideInInspector] public bool IsFinalTileSelected;
    public Transform FinalTilePosition;
    public bool bIsFinalTileInPosition;
    public PuzzleManager puzzleManager;

    private void Start()
    {
        TargetPosition = transform.position;

    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1) && IsFinalTileSelected)
        {
            TargetPosition = FinalTilePosition.position;
            Invoke(nameof(TileInPosition), 2f);
        }


        transform.position = Vector3.MoveTowards(transform.position, TargetPosition, MoveSpeed * Time.deltaTime);


        
    }

    public void TileInPosition()
    {
        bIsFinalTileInPosition = true;
        puzzleManager.GameComplete();
    }

    private void OnMouseDown()
    {
        IsFinalTileSelected = true;
    }
}
