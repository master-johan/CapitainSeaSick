using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 0f;
    private float timer = 1f;
    // Update is called once per frame
    void Update()
    {
      
        Debug.Log(GameObject.Find("TimeLine").GetComponentInChildren<ProgressBar_Script>().progress);
        if (GameObject.Find("TimeLine").GetComponentInChildren<ProgressBar_Script>().progress <= 0)
        {
            LoadNextLevel();
          
        }

    }

    public void LoadNextLevel()
    {
        //Debug.Log("Load next");
        Debug.Log("Next LevelIndex " + (SceneManager.GetActiveScene().buildIndex + 1));
       StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        //Debug.Log("Next LevelIndex" + levelIndex);

        transition.SetTrigger("Start");
        SceneManager.LoadScene(levelIndex);
        yield return new WaitForSeconds(transitionTime);

    }
}
