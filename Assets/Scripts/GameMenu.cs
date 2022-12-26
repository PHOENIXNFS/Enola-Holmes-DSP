using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    [HideInInspector] public int LevelToLoad;
    public static bool bNewGamePressed;
    public static bool bContinueGamePressed;

    public void Awake()
    {
        bNewGamePressed = false;
        bContinueGamePressed = false;
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
        LevelToLoad = PlayerPrefs.GetInt("SavedScene");
        SceneManager.LoadScene(LevelToLoad);

    }

    public void LoadScemeAsync()
    {
        bContinueGamePressed = true;
        LevelToLoad = PlayerPrefs.GetInt("SavedScene");
        SceneManager.LoadSceneAsync(LevelToLoad);

    }

}
