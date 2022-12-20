using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle : MonoBehaviour
{
    public PuzzleBox puzzleBoxPrefab;

    public PuzzleBox[,] puzzleBoxes = new PuzzleBox[4, 4];

    public Sprite[] sprites;

    private void Start()
    {
        Init();
        for (int i = 0; i < 100; i++)
            Shuffle();
    }

    void Init()
    {
        int n = 0;
        for (int y = 3; y >= 0; y--)
            for(int x = 0; x < 4; x++)
            {
                PuzzleBox puzzleBox = Instantiate(puzzleBoxPrefab, new Vector2(x, y), Quaternion.identity);
                puzzleBox.Init(x, y, n + 1, sprites[n], ClickToSwap);
                puzzleBoxes[x, y] = puzzleBox;
                n++;
            }
    }

    void ClickToSwap(int x, int y)
    {
        int dx = GetDirectionX(x, y);
        int dy = GetDirectionY(x, y);
        Swap(x, y, dx, dy);
    }

    void Swap(int x, int y, int dx, int dy)
    {
        var from = puzzleBoxes[x, y];
        var target = puzzleBoxes[x + dx, y + dy];

        //Swap boxes
        puzzleBoxes[x, y] = target;
        puzzleBoxes[x + dx, y + dy] = from;

        //Swap position
        from.UpdatePosition(x + dx, y + dy);
        target.UpdatePosition(x, y);
    }

    int GetDirectionX(int x, int y)
    {
        if (x < 3 && puzzleBoxes[x + 1, y].IsPositionEmpty())
            return 1;
        if (x > 0 && puzzleBoxes[x - 1, y].IsPositionEmpty())
            return -1;

        return 0;
    }

    int GetDirectionY(int x, int y)
    {
        if (y < 3 && puzzleBoxes[x, y + 1].IsPositionEmpty())
            return 1;
        if (y > 0 && puzzleBoxes[x, y - 1].IsPositionEmpty())
            return -1;

        return 0;
    }

    void Shuffle()
    {
        for(int i = 0; i < 4; i++)
        {
            for(int j = 0; j < 4; j++)
            {
                if(puzzleBoxes[i, j].IsPositionEmpty())
                {
                    Vector2 newposition = GetRandomValidMove(i, j);
                    Swap(i, j, (int)newposition.x, (int)newposition.y);
                }
            }
        }
    }

    private Vector2 LastPosition;
    Vector2 GetRandomValidMove(int x, int y)
    {
        Vector2 validposition = new Vector2();
        do
        {
            int random = Random.Range(0, 4);
            if (random == 0)
                validposition = Vector2.up;
            if (random == 1)
                validposition = Vector2.down;
            if (random == 2)
                validposition = Vector2.left;
            if (random == 3)
                validposition = Vector2.right;

        } while (!(IsValidRange(x + (int)validposition.x) && IsValidRange(y + (int)validposition.y)) || IsRepeatMove(validposition));

        LastPosition = validposition;
        return validposition;
    }
    
    bool IsValidRange(int n)
    {
        return n >= 0 && n < 4;
    }

    bool IsRepeatMove(Vector2 pos)
    {
        return pos * -1 == LastPosition;
    }


}
