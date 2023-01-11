using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToMenu : MonoBehaviour
{
    [HideInInspector] public int SavedSceneIndex;
    public GameObject Player;
    public bool bIsReturnToMenuPressed;

    public static ReturnToMenu returnToMenuInstance { get; private set; }

    private void Awake()
    {
        if (returnToMenuInstance != null && returnToMenuInstance != this)
        {
            Destroy(gameObject);

        }
        else
        {
            returnToMenuInstance = this;
        }
        DontDestroyOnLoad(this);

    }

    private void Start()
    {
        if (GameMenu.bNewGamePressed == true)
        {
            GameMenu.bNewGamePressed = false;
        }

        if (GameMenu.bContinueGamePressed == true)
        {
            GameMenu.bContinueGamePressed = false;
            LoadGame();
        }
        bIsReturnToMenuPressed = false;
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.Escape) && !bIsReturnToMenuPressed)
        {
            bIsReturnToMenuPressed = true;
            SaveGame();
            SaveScene();
        }
    }

    public void SaveGame()
    {
        SaveData saveData = new SaveData();
        saveData.playerposition = new SaveData.PlayerPosition[1];
        saveData.playerposition[0] = new SaveData.PlayerPosition();
        saveData.playerposition[0].XPlayer = Player.transform.position.x;
        saveData.playerposition[0].YPlayer = Player.transform.position.y;
        saveData.playerposition[0].ZPlayer = Player.transform.position.z;
        GameSaveManager.SaveGameState(saveData);
    }

    public void LoadGame()
    {
        SaveData saveData = GameSaveManager.LoadGameState(); 
        if(saveData !=  null)
        {
            Player.transform.position = new Vector3(saveData.playerposition[0].XPlayer, saveData.playerposition[0].YPlayer, saveData.playerposition[0].ZPlayer);
        }
    }

    public void SaveScene()
    {
        //SavedSceneIndex = SceneManager.GetActiveScene().buildIndex;
        //PlayerPrefs.SetInt("SavedScene", SavedSceneIndex);
        //SceneManager.LoadSceneAsync("Game Main Menu");
        //SceneManager.UnloadSceneAsync("TestLevel");
        GameManager.gameManagerInstance.LoadScene("Game Main Menu");
    }
}
