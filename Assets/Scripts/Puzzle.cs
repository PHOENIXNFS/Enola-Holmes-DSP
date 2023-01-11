using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle : MonoBehaviour
{
    public PuzzleBox puzzleBoxPrefab;

    public PuzzleBox[,] puzzleBoxes = new PuzzleBox[4, 4];

    public Sprite[] sprites;

    //public int CorrectTilesCounter;

    public int TempCounter;

    public bool bisAllTilesInPosition;

    public PuzzleManager puzzleManager;

    private void Start()
    {
        Init();
        for (int i = 0; i < 1; i++)
            Shuffle();
        //CorrectTilesCounter = 0;
        bisAllTilesInPosition = false;
    }

    private void Update()
    {
        //AllTilesInPosition();
        //GameFinished();
    }

    void Init()
    {
        int n = 0;
        for (int y = 3; y >= 0; y--)
            for(int x = 0; x < 4; x++)
            {
                PuzzleBox puzzleBox = Instantiate(puzzleBoxPrefab, new Vector2(x, y), Quaternion.identity, transform);
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
        //bisAllTilesInPosition = AllTilesInPosition();
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

        Invoke(nameof(AllTilesInPosition), 0.5f);

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

    public bool AllTilesInPosition()
    {
        //Debug.Log(puzzleBoxes.Length);
        TempCounter = 0;
        bool _bisAllTilesInPosition = true;

        //for (int i = 0; i < 4; i++)
        //{
        //    for (int j = 0; j < 4; j++)
        //    {

        //        //Debug.Log("i: " + i + " j: " + j);
        //        TempCounter++;
        //        Debug.LogFormat("Temp counter {0} | Index {1} | (i,j) = {2},{3}",TempCounter, puzzleBoxes[i, j].index, i , j);
        //        if(puzzleBoxes[i, j].index != TempCounter)
        //        {
        //            _bisAllTilesInPosition = false;
        //            bisAllTilesInPosition = _bisAllTilesInPosition;
        //            return _bisAllTilesInPosition;
        //        }
        //    }
        //}

        for (int j = 3; j >= 0; j--)
            for (int i = 0; i < 4; i++)
            {

                //Debug.Log("i: " + i + " j: " + j);
                TempCounter++;
                //Debug.LogFormat("Temp counter {0} | Index {1} | (i,j) = {2},{3}", TempCounter, puzzleBoxes[i, j].index, i, j);
                if (puzzleBoxes[i, j].index != TempCounter)
                {
                    _bisAllTilesInPosition = false;
                    bisAllTilesInPosition = _bisAllTilesInPosition;
                    return _bisAllTilesInPosition;
                }
            }
        //Debug.Log(_bisAllTilesInPosition);
        bisAllTilesInPosition = _bisAllTilesInPosition;
        puzzleManager.GameComplete();
        return _bisAllTilesInPosition;
        //Debug.Log(bisAllTilesInPosition);
    }

   //void GameFinished()
   //{
   //   if (CorrectTilesCounter == 16)
   //  {
   //    bisAllTilesInPosition = true;
   //  Debug.Log(bisAllTilesInPosition);
   //}
   //}

}
