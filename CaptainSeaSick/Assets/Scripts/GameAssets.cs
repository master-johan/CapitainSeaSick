using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    //AudioClip Array Used in SoundManager
    [Header("Audiofile Array")]
    public AudioClip[] audioClips;
    //Variabler
    [Header("Ship Variables")]
    [Tooltip(("Ship health, a value between 0 and 100."))]
    public float ShipMaxHealth;
    [Header("Dialogue Variables")]
    [Tooltip("Typing speed in dialogue")]
    public float DialogueTypingSpeed;
    [Header("Damage Variables")]
    [Tooltip("Enemy cannonball damage")]
    public float EnemyCannonBallDamage;
    [Tooltip("Leak damage over time")]
    public float LeakDamage;
    //Prefabs
    [Header("Prefabs")]
    public GameObject cliffPrefab;
    public GameObject hatPrefab;
    public GameObject plankPrefab;
    public GameObject cannonPrefab;
    public GameObject cannonBallPrefab;
}
