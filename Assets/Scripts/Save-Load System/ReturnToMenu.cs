using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToMenu : MonoBehaviour
{
    [HideInInspector] public int SavedSceneIndex;

    private void Awake()
    {
        if(GameMenu.bNewGamePressed == true)
        {
            GameMenu.bNewGamePressed = false;
        }

        if(GameMenu.bContinueGamePressed == true)
        {
            GameMenu.bContinueGamePressed = false;
            LoadGame();
        }
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            SaveGame();
            SaveScene();
        }
    }

    private void SaveGame()
    {
        SaveData saveData = new SaveData();
        saveData.playerposition = new SaveData.PlayerPosition[1];
        saveData.playerposition[0] = new SaveData.PlayerPosition();
        saveData.playerposition[0].XPlayer = transform.position.x;
        saveData.playerposition[0].YPlayer = transform.position.y;
        saveData.playerposition[0].ZPlayer = transform.position.z;
        GameSaveManager.SaveGameState(saveData);
    }

    public void LoadGame()
    {
        SaveData saveData = GameSaveManager.LoadGameState(); 
        if(saveData !=  null)
        {
            transform.position = new Vector3(saveData.playerposition[0].XPlayer, saveData.playerposition[0].YPlayer, saveData.playerposition[0].ZPlayer);
        }
    }

    public void SaveScene()
    {
        SavedSceneIndex = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("SavedScene", SavedSceneIndex);
        SceneManager.LoadScene("Game Main Menu");
    }
}
