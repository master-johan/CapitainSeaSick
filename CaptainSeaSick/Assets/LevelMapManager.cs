using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelMapManager : MonoBehaviour
{
    GameObject Level21, Level22;
    GameObject Level31, Level32, Level33;
    GameObject Level41;
    GameObject Level51, Level52;
    GameObject Level61;
    void Start()
    {
        Level21 = GameObject.Find("Level 2 : 1");
        Level22 = GameObject.Find("Level 2 : 2");

        Level31 = GameObject.Find("Level 3 : 1");
        Level32 = GameObject.Find("Level 3 : 2");
        Level33 = GameObject.Find("Level 3 : 3");

        Level41 = GameObject.Find("Level 4 : 1");

        Level51 = GameObject.Find("Level 5 : 1");
        Level52 = GameObject.Find("Level 5 : 2");

        Level61 = GameObject.Find("Level 6 : 1");
    }

    // Update is called once per frame
    void Update()
    {
        Level21.GetComponent<Button>().interactable = GameAssets.instance.enableLevel2;
        Level22.GetComponent<Button>().interactable = GameAssets.instance.enableLevel2;

        Level31.GetComponent<Button>().interactable = GameAssets.instance.enableLevel3left;
        Level32.GetComponent<Button>().interactable = GameAssets.instance.enableLevel3left;

        Level32.GetComponent<Button>().interactable = GameAssets.instance.enableLevel3right;
        Level33.GetComponent<Button>().interactable = GameAssets.instance.enableLevel3right;

        Level41.GetComponent<Button>().interactable = GameAssets.instance.enableLevel4;

        Level51.GetComponent<Button>().interactable = GameAssets.instance.enableLevel5;
        Level52.GetComponent<Button>().interactable = GameAssets.instance.enableLevel5;

        Level61.GetComponent<Button>().interactable = GameAssets.instance.enableLevel6;
    }
    /// <summary>
    /// Enabling all the levels on the diffrent buttonclicks.
    /// </summary>
    #region
    public void EnableLevel2()
    {
        GameAssets.instance.enableLevel2 = true;
    }

    public void EnableLevel31And32()
    {
        GameAssets.instance.enableLevel3left = true;
    }
    public void EnableLevel32And33()
    {
        GameAssets.instance.enableLevel3right = true;
    }
    public void EnableLevel41()
    {
        GameAssets.instance.enableLevel4 = true;
    }
    public void EnableLevel51And52()
    {
        GameAssets.instance.enableLevel5 = true;
    }
    public void EnableLevel61()
    {
        GameAssets.instance.enableLevel6 = true;
    }
    #endregion

    /// <summary>
    /// Starting the level on the correct button
    /// </summary>
    #region
    public void StartLevel1()
    {
        StartCoroutine(GameObject.Find("LevelLoader").GetComponent<LevelLoader>().LoadLevel(3));
    }
    public void StartLevel21()
    {
        StartCoroutine(GameObject.Find("LevelLoader").GetComponent<LevelLoader>().LoadLevel(5));
        GameObject.Find("CountDownManager").GetComponentInChildren<Countdown_Script>().StartCountDown();
        GameAssets.instance.playersReady = true;
    }
    public void StartLevel22()
    {
        //StartCoroutine(GameObject.Find("LevelLoader").GetComponent<LevelLoader>().LoadLevel(7));
        GameAssets.instance.playersReady = true;

    }
    public void StartLevel31()
    {
        //StartCoroutine(GameObject.Find("LevelLoader").GetComponent<LevelLoader>().LoadLevel(9));
        GameAssets.instance.playersReady = true;
        StartCoroutine(GameObject.Find("LevelLoader").GetComponent<LevelLoader>().LoadLevel(7));

    }
    public void StartLevel32()
    {
        //StartCoroutine(GameObject.Find("LevelLoader").GetComponent<LevelLoader>().LoadLevel(5));
        GameAssets.instance.playersReady = true;
        StartCoroutine(GameObject.Find("LevelLoader").GetComponent<LevelLoader>().LoadLevel(9));

    }
    public void StartLevel33()
    {
        //StartCoroutine(GameObject.Find("LevelLoader").GetComponent<LevelLoader>().LoadLevel(5));
        GameAssets.instance.playersReady = true;

    }
    public void StartLevel41()
    {
        //StartCoroutine(GameObject.Find("LevelLoader").GetComponent<LevelLoader>().LoadLevel(5));
        GameAssets.instance.playersReady = true;


    }
    public void StartLevel51()
    {
        //StartCoroutine(GameObject.Find("LevelLoader").GetComponent<LevelLoader>().LoadLevel(5));
        GameAssets.instance.playersReady = true;

    }
    public void StartLevel52()
    {
        //StartCoroutine(GameObject.Find("LevelLoader").GetComponent<LevelLoader>().LoadLevel(5));
        GameAssets.instance.playersReady = true;

    }
    public void StartLevel61()
    {
        //StartCoroutine(GameObject.Find("LevelLoader").GetComponent<LevelLoader>().LoadLevel(5));
        GameAssets.instance.playersReady = true;

    }
    #endregion
}
