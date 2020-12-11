using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime;
    private float timer = 1f;
    public int scenIndex;

    GameObject[] players;
    // Update is called once per frame

    void Start()
    {
        scenIndex = SceneManager.GetActiveScene().buildIndex;
        Debug.Log("Current scene: " + scenIndex);
        GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>().SetSceneIndex(scenIndex);

    }
    void Update()
    {

        //Debug.Log("Scen index " + scenIndex.ToString());
        //if (GameObject.Find("TimeLine").GetComponentInChildren<ProgressBar_Script>().progress <= 0)
        //{
        //    LoadNextLevel();

        //}

        
    }
    /// <summary>
    /// Increse the value of buildIndex and changes active scene. The coroutine LoadLevel gets called
    /// </summary>
    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
       
    }
    /// <summary>
    /// Enumetator that controlls the transition time between the scenes
    /// </summary>
    /// <param name="levelIndex"></param>
    /// <returns></returns>
    public IEnumerator LoadLevel(int levelIndex)
    {
        SetPlayerSpawningPos();

        transition.SetTrigger("Start");
        SceneManager.LoadScene(levelIndex);
        yield return new WaitForSeconds(transitionTime);
        //GameObject.Find("CountDownManager").GetComponentInChildren<Countdown_Script>().StartCountDown();
    }

    private void SetPlayerSpawningPos()
    {
        players = GameObject.FindGameObjectsWithTag("Player");

        string nextSceneName = NameOfSceneByBuildIndex(SceneManager.GetActiveScene().buildIndex + 1);
        char[] nextSceneCharArray = nextSceneName.ToCharArray();

        string[] scavOrShip = new string[2];
        bool[] scavOrShipBool = new bool[2];
        scavOrShip[0] = "Scav";
        scavOrShip[1] = "Ship";

        for (int i = 0; i < scavOrShip.Length; i++)
        {
            for (int j = 0; j < scavOrShip[0].Length; j++)
            {
                if (i == 0 && nextSceneName[j].ToString() == scavOrShip[j])
                {
                    scavOrShipBool[i] = true;
                }
                else if (i == 1 && nextSceneName[j].ToString() == scavOrShip[j])
                {
                    scavOrShipBool[i] = true;
                }
                else
                {
                    scavOrShipBool[i] = false;
                }
            }
        }

        if (nextSceneName == "Ship")
        {
            for (int i = 0; i < players.Length; i++)
            {
                players[i].GetComponent<PlayerActions>().Clear();
                players[i].transform.position = GameAssets.instance.spawnPositions[i] + GameAssets.instance.spawnBoatPhase;
            }
        }
        else
        {
            for (int i = 0; i < players.Length; i++)
            {
                players[i].GetComponent<PlayerActions>().Clear();
                //players[i].transform.position = GameAssets.instance.spawnPositions[i] + GameAssets.instance.spawnScavPhase;
            }
        }
    }

    public void LoadShopLevel()
    {
        StartCoroutine(LoadLevel(2));
    }
    public void LoadLevelMap()
    {
        StartCoroutine(LoadLevel(1));
    }
    public string NameOfSceneByBuildIndex(int buildIndex)
    {
        string path = SceneUtility.GetScenePathByBuildIndex(buildIndex);
        int slash = path.LastIndexOf('/');
        string name = path.Substring(slash + 1);
        int dot = name.LastIndexOf('.');
        return name.Substring(0, dot);
    }
}
