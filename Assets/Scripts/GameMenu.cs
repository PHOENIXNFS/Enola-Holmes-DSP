using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    [HideInInspector] public int LevelToLoad;
    public static bool bNewGamePressed;
    public static bool bContinueGamePressed;

    //public static GameMenu gameMenuInstance {get; private set;}

public void Awake()
    {
        
        bNewGamePressed = false;
        bContinueGamePressed = false;
        //if (gameMenuInstance != null && gameMenuInstance != this)
        //{
        //    Destroy(gameObject);

        //}
        //else
        //{
        //    gameMenuInstance = this;
        //}
        //DontDestroyOnLoad(this);
    }

    public void NewGame()
    {
        bNewGamePressed = true;
        SceneManager.LoadScene("TestLevel");
    }

    public void GameQuit()
    {
        Application.Quit();
        //UnityEditor.EditorApplication.isPlaying = false;
    }

    public void LoadSceme()
    {
        bContinueGamePressed = true;
        //LevelToLoad = PlayerPrefs.GetInt("SavedScene");
        //SceneManager.LoadScene(LevelToLoad);
        GameManager.gameManagerInstance.returnToMenu.bIsReturnToMenuPressed = false;
        GameManager.gameManagerInstance.UnloadScene("Game Main Menu");

    }

    public void LoadScemeAsync()
    {
        bContinueGamePressed = true;
        LevelToLoad = PlayerPrefs.GetInt("SavedScene");
        SceneManager.LoadSceneAsync(LevelToLoad);
        //SceneManager.UnloadSceneAsync("Game Main Menu");

    }

}
