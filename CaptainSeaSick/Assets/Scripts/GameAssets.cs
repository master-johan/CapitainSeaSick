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
            if (_instance == null) _instance = (Instantiate(Resources.Load("GameAssets"), new Vector3(-16.37f, 0, 10.31f), Quaternion.identity) as GameObject).GetComponent<GameAssets>();

            DontDestroyOnLoad(_instance);
            return _instance;

        }
    }

    //AudioClip Array Used in SoundManager
    [Header("Audiofile Array")]
    public AudioClip[] audioClips;

    [Header("Player Spawn Positions")]
    public Vector3[] spawnPositions;
    /// <summary>
    /// Variables
    /// </summary>
    [Header("Ship Variables")]
    [Tooltip(("Ship health, a value between 0 and 100."))]
    public float ShipMaxHealth;
    [Tooltip(("Time between cliffs"))]
    public float cliffSpeed;
    public float cannonballsDamage;

    public int numberOfCannons;
    public List<Vector3> cannonSpawnPos;
    public int numberOfSwords;
    public List<Vector3> swordSpawnPos;


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

    
}
