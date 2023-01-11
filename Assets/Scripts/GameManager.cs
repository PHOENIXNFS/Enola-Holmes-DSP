using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject Table;
    public GameObject MycroftRoom;
    public GameObject Player;
    public GameObject Canvas;
    public Vector3 CanvasOriginalSize;

    public Inventory_Canvas inventoryCanvas;
    public ReturnToMenu returnToMenu;
    public GameAudioManager gameAudioManager;
    public static GameManager gameManagerInstance { get; private set; }

    private void Awake()
    {
        if(gameManagerInstance != null && gameManagerInstance != this)
        {
            Destroy(gameObject);

        }
        else
        {
            gameManagerInstance = this;
        }
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        inventoryCanvas = FindObjectOfType<Inventory_Canvas>();
        returnToMenu = FindObjectOfType<ReturnToMenu>();
        gameAudioManager = FindObjectOfType<GameAudioManager>();
        CanvasOriginalSize = Canvas.transform.localScale;
    }

    public void LoadScene(string _sceneName)
    {
        //Hide camera and other objects before loading the screen
        mainCamera.SetActive(false);
        Table.SetActive(false);
        MycroftRoom.SetActive(false);
        Player.SetActive(false);
        Canvas.transform.localScale = Vector3.zero;

        //Load the given scene
        SceneManager.LoadSceneAsync(_sceneName, LoadSceneMode.Additive);
    }

    public void UnloadScene(string _sceneName)
    {
        //Unload the scene
        SceneManager.UnloadSceneAsync(_sceneName);

        //Show the camera and other objects
        mainCamera.SetActive(true);
        Table.SetActive(true);
        MycroftRoom.SetActive(true);
        Player.SetActive(true);
        Canvas.transform.localScale = CanvasOriginalSize;
    }
}
