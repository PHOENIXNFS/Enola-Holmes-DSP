using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class InventoryButtonFunctionality : MonoBehaviour
{
    public ReturnToMenu returnToMenu;
    public GameMenu gameMenu;
    public GameObject inventory_Canvas;

    public void PicturePuzzleButton()
    {
        inventory_Canvas.SetActive(false);

        returnToMenu.SaveScene();
        returnToMenu.SaveGame();
        
        SceneManager.LoadSceneAsync("Puzzle");
        SceneManager.UnloadSceneAsync("Test Level");
    }

}
