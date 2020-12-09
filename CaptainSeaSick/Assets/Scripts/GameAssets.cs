using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class GameAssets : MonoBehaviour
{
    private static GameAssets _instance;
    public static GameAssets instance
    {
        get
        {
            //If there is no gameasset active instantiate this gameAsset
            if (_instance == null) _instance = (Instantiate(Resources.Load("GameAssets"), new Vector3(-16.37f, 0, 10.31f), Quaternion.identity) as GameObject).GetComponent<GameAssets>();

            DontDestroyOnLoad(_instance);
            return _instance;

        }
    }
    public bool CountDownDone = false;
    public bool gameIsPaused;
    //Array of images for information
    public Sprite[] infoImages;
    //AudioClip Array Used in SoundManager
    [Header("Audiofile Array")]
    public AudioClip[] audioClips;

    public AudioClip[] soundEffects;

    [Header("Player Spawn Positions")]
    public Vector3[] spawnPositions;
    /// <summary>
    /// Variables
    /// </summary>
    /// 
    [Header("Player Variables")]
    public bool playersReady;

    [Header("Ship Variables")]
    [Tooltip(("Ship health, a value between 0 and 100."))]
    public float ShipMaxHealth;
    [Tooltip(("Time between cliffs"))]
    public float cliffSpeed;
    public float cannonballsDamage;
    public int levelTime;
    public int numberOfCannons;
    public List<Vector3> cannonSpawnPos;
    public int numberOfSwords;
    public List<Vector3> swordSpawnPos;

    [Header("Shop Variables")]
    [Tooltip(("Prices for different upgrades"))]
    public int swordPrice;
    public int cannonPrice;
    public int cannonballDamagePrice;
    public int shipMaxHealthPrice;
    public bool cannonFull;
    public bool cannonDamageFull;
    public bool swordFull;
    public bool maxHealthFull;



    [Header("Dialogue Variables")]
    [Tooltip("Typing speed in dialogue")]
    public float DialogueTypingSpeed;
    [Header("Damage Variables")]
    [Tooltip("Enemy cannonball damage")]
    public float EnemyCannonBallDamage;
    [Tooltip("Leak damage over time")]
    public float LeakDamage;

    /// <summary>
    /// Scavenging phase
    /// </summary>
    [Header("Scavenging Phase")]
    [Tooltip("Scavenging phase Timer 1")]
    public float ScavLevelTimer1;
    [Tooltip("Scavenging Gold")]
    public float gold;
    /// <summary>
    /// Prefabs
    /// </summary>
    [Header("Prefabs")]
    public GameObject cliffPrefab;
    public GameObject hatPrefab;
    public GameObject plankPrefab;
    public GameObject cannonPrefab;
    public GameObject cannonBallPrefab;
    public GameObject rollingBarrelPrefab;
    public GameObject dropZonePrefab;
    public GameObject swordPrefab;

    [Header("Spawn Different Scenes")]
    public Vector3 spawnBoatPhase;
    public Vector3 spawnScavPhase;

    [Header("Level Enabling Bools")]
    public bool enableLevel1;
    public bool enableLevel2;
    public bool enableLevel3left;
    public bool enableLevel3right;
    public bool enableLevel4;
    public bool enableLevel5;
    public bool enableLevel6;

    [Header("Completed Level Bools")]
    public bool level11Win;
    public bool level21Win;
    public bool level22Win;
    public bool level31Win;
    public bool level32Win;
    public bool level33Win;
    public bool level41Win;
    public bool level51Win;
    public bool level52Win;
    public bool level61Win;


    [Header("Wind Variables")]
    public bool windActivated;

    [Header("Captain Dialogues")]
    public Dialogue startLevelDialogue;
    public Dialogue shipSpawnDialogue;
    public Dialogue cliffSpawnDialogue;
    public Dialogue battleSpawnDialogue;
    public Dialogue leakSpawnDialogue;
    public Dialogue scavengingPhase;
    public Dialogue randomDialogue;

    [Header ("Audio Mixer")]
    public AudioMixer audioMixer;

    public void PauseGame()
    {
        Time.timeScale = 0f;
    }

    public void UnPauseGame()
    {
        Time.timeScale = 1;
    }


}
