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
        SetPlayerSpawningPos(levelIndex);

        transition.SetTrigger("Start");
        SceneManager.LoadScene(levelIndex);
        yield return new WaitForSeconds(transitionTime);
        //GameObject.Find("CountDownManager").GetComponentInChildren<Countdown_Script>().StartCountDown();
    }

    private void SetPlayerSpawningPos(int levelindex)
    {
        players = GameObject.FindGameObjectsWithTag("Player");

        string nextSceneName = NameOfSceneByBuildIndex(levelindex);
        char[] nextSceneCharArray = nextSceneName.ToCharArray();

        string[] scavOrShip = new string[2];
        scavOrShip[0] = "Scav";
        scavOrShip[1] = "Ship";
        bool[] scavOrShipBool = new bool[2];
        char[] scavCharArray = scavOrShip[0].ToCharArray();
        char[] shipCharArray = scavOrShip[1].ToCharArray();

        for (int i = 0; i < scavOrShip.Length; i++)
        {
            for (int j = 0; j < scavOrShip[0].Length; j++)
            {
                if (i == 0 && nextSceneCharArray[j] == scavCharArray[j])
                {
                    scavOrShipBool[i] = true;
                }
                else if (i == 1 && nextSceneCharArray[j] == shipCharArray[j])
                {
                    scavOrShipBool[i] = true;
                }
                else
                {
                    scavOrShipBool[i] = false;
                }
            }
        }

        bool[] whatScavBoolArray = new bool[4];

        if (scavOrShipBool[0])
        {
            if (nextSceneCharArray[nextSceneCharArray.Length - 1] == '1')
            {
                whatScavBoolArray[0] = true;
            }
            else if (nextSceneCharArray[nextSceneCharArray.Length - 1] == '3')
            {
                whatScavBoolArray[1] = true;
            }
            else if (nextSceneCharArray[nextSceneCharArray.Length - 1] == '4')
            {
                whatScavBoolArray[2] = true;
            }
            else if (nextSceneCharArray[nextSceneCharArray.Length - 1] == '5')
            {
                whatScavBoolArray[3] = true;
            }
        }

        if (scavOrShipBool[1])
        {
            for (int i = 0; i < players.Length; i++)
            {
                players[i].GetComponent<PlayerActions>().Clear();
                players[i].transform.position = GameAssets.instance.spawnPositions[i] + GameAssets.instance.spawnBoatPhase;
            }
        }
        else if(scavOrShipBool[0])
        {
            for (int i = 0; i < whatScavBoolArray.Length; i++)
            {
                if (whatScavBoolArray[i])
                {
                    for (int j = 0; j < players.Length; j++)
                    {
                        players[j].GetComponent<PlayerActions>().Clear();
                        players[j].transform.position = GameAssets.instance.spawnPositions[j] + GameAssets.instance.spawnScavPhase[i];
                    }
                }
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
