using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAudioManager : MonoBehaviour
{
    public static GameAudioManager gameAudioManagerInstance { get; private set; }

    private void Awake()
    {
        if (gameAudioManagerInstance != null && gameAudioManagerInstance != this)
        {
            Destroy(gameObject);

        }
        else
        {
            gameAudioManagerInstance = this;
        }
        DontDestroyOnLoad(this);
    }
}
