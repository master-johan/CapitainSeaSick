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
    // Update is called once per frame

    void Start()
    {
        scenIndex = SceneManager.GetActiveScene().buildIndex; 
    }
    void Update()
    {

        Debug.Log("Scen index " + scenIndex.ToString());
        if (GameObject.Find("TimeLine").GetComponentInChildren<ProgressBar_Script>().progress <= 0)
        {
            LoadNextLevel();

        }

        
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
    IEnumerator LoadLevel(int levelIndex)
    {

        transition.SetTrigger("Start");
        SceneManager.LoadScene(levelIndex);
        yield return new WaitForSeconds(transitionTime);

    }
}
