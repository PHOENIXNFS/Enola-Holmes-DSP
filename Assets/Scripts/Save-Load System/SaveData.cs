using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public PlayerPosition[] playerposition;

    [System.Serializable]
    public class PlayerPosition
    {
        public float XPlayer;
        public float YPlayer;
        public float ZPlayer;
    }
}
