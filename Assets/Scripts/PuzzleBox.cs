using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PuzzleBox : MonoBehaviour
{
    public int index = 0;
    int x = 0;
    int y = 0;

    private Action<int, int> swapFunc = null;
    public Puzzle puzzle;

    private void Start()
    {
        puzzle = FindObjectOfType<Puzzle>();
    }

    public void Init(int i, int j, int index, Sprite sprite, Action<int, int> swapFunc)
    {
        this.index = index;
        this.GetComponent<SpriteRenderer>().sprite = sprite;
        UpdatePosition(i, j);
        this.swapFunc = swapFunc;
    }

    public void UpdatePosition(int i, int j)
    {
        x = i;
        y = j;

        StartCoroutine(Move());
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0) && swapFunc != null)
        {
            swapFunc(x, y);
        }
    }

    public bool IsPositionEmpty()
    {
        return index == 16;
    }

    IEnumerator Move()
    {
        float elapsedTime = 0;
        float duration = 0.3f;
        Vector2 StartPosition = this.gameObject.transform.localPosition;
        Vector2 EndPosition = new Vector2(x, y);

        while (elapsedTime < duration)
        {
            this.gameObject.transform.localPosition = Vector2.Lerp(StartPosition, EndPosition, (elapsedTime / duration));
            elapsedTime += Time.deltaTime;
            yield return null;

        }

        this.gameObject.transform.localPosition = EndPosition;
        //puzzle.AllTilesInPosition();
    }
}
