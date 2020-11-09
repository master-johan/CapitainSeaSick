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
        players = GameObject.FindGameObjectsWithTag("Player");
        if (SceneManager.GetActiveScene().buildIndex % 2 == 0)
        {
            for (int i = 0; i < players.Length; i++)
            {
                players[i].transform.position = GameAssets.instance.spawnPositions[i] + GameAssets.instance.spawnBoatPhase;
            }
        }
        else
        {
            for (int i = 0; i < players.Length; i++)
            {
                players[i].transform.position = GameAssets.instance.spawnPositions[i] + GameAssets.instance.spawnScavPhase;
            }
        }

        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }
    /// <summary>
    /// Enumetator that controlls the transition time between the scenes
    /// </summary>
    /// <param name="levelIndex"></param>
    /// <returns></returns>
    IEnumerator LoadLevel(int levelIndex)
    {

        transition.SetTrigger("Start");
        SceneManager.LoadScene(levelIndex);
        yield return new WaitForSeconds(transitionTime);

    }

    public void LoadShopLevel()
    {
        StartCoroutine(LoadLevel(0));
    }
    public void LoadLevelMap()
    {
        StartCoroutine(LoadLevel(1));
    }
}
