using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAssets : MonoBehaviour
{
    private static GameAssets _instance;
    public static GameAssets instance
    {
        get
        {
            //If there is no gameasset active instantiate this gameAsset
            if (_instance == null) _instance = (Instantiate(Resources.Load("GameAssets")) as GameObject).GetComponent<GameAssets>();
            return _instance;
        }
    }

    //AudioClip Array Use in SoundManager
    public AudioClip[] audioClips;

    //Variables

}
