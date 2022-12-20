using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    [SerializeField] private Transform PuzzleBox;
    [SerializeField] private Transform PuzzlePiece;

    private int emptylocation;
    private int size;
    private void Start()
    {
        size = 4;
        CreatePuzzlePieces(0.1f);
    }

    private void CreatePuzzlePieces(float GapThickness)
    {
        float width = 1 / (float)size;
        for (int row = 0; row < size; row++)
        {
            for (int column = 0; column < size; column++)
            {
                Transform piece = Instantiate(PuzzlePiece, PuzzleBox);
                piece.localPosition = new Vector3(-1 + (2 * width * column) + width,
                                                   +1 - (2 * width * column) - width,
                                                   0);
                piece.localScale = ((2 * width) - GapThickness) * Vector3.one;
                piece.name = $"{(row * size) + column}";
                if ((row == size - 1) && (column == size - 1))
                {
                    emptylocation = (size * size) - 1;
                    piece.gameObject.SetActive(false);
                }
            }
        }
           
    }
}
