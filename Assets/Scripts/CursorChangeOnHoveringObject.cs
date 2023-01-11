using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorChangeOnHoveringObject : MonoBehaviour
{
    public Texture2D EyeCursorTexture;
    public Texture2D OriginalTexture;
    public CursorMode cursorMode = CursorMode.ForceSoftware;
    public Vector2 cursorHotspot = Vector2.zero;

    private void Awake()
    {
        Cursor.SetCursor(OriginalTexture, cursorHotspot, cursorMode);
    }

    private void OnMouseEnter()
    {
        //if(other.gameObject.name == this.gameObject.name)
        //{
            Cursor.SetCursor(EyeCursorTexture, cursorHotspot, cursorMode);
        //}
    }

    private void OnMouseExit()
    {
        //if(collider.gameObject.name == this.gameObject.name)
        //{
            Cursor.SetCursor(OriginalTexture, cursorHotspot, cursorMode);
        //}
    }

    //private void OnMouseOver()
    //{
    //    Cursor.SetCursor(EyeCursorTexture, cursorHotspot, cursorMode);
    //}
}
