using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelMapManager : MonoBehaviour
{
    GameObject Level11;
    GameObject Level21, Level22;
    GameObject Level31, Level32, Level33;
    GameObject Level41;
    GameObject Level51, Level52;
    GameObject Level61;

    GameObject tick, tick1, tick2, tick3, tick4, tick5, tick6, tick7, tick8, tick9;

    public Sprite hasWon;
    public EventSystem eventSystem;
    public GameObject LevelName, LevelDifficulty;
    void Start()
    {
        DeclareSprites();
        DeclareLevels();
        SelectCorrcetLevelOnLoad();
        ChangePictureOnWin();

    }

    private void DeclareSprites()
    {
        tick = GameObject.Find("Tick");
        tick1 = GameObject.Find("Tick (1)");
        tick2 = GameObject.Find("Tick (2)");
        tick3 = GameObject.Find("Tick (3)");
        tick4 = GameObject.Find("Tick (4)");
        tick5 = GameObject.Find("Tick (5)");
        tick6 = GameObject.Find("Tick (6)");
        tick7 = GameObject.Find("Tick (7)");
        tick8 = GameObject.Find("Tick (8)");
        tick9 = GameObject.Find("Tick (9)");
    }
    private void DeclareLevels()
    {
        Level11 = GameObject.Find("Level 1 : 1");

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
    void Update()
    {
        ChangeNameAndDifficulty();
        EnableLevels();
    }
    private void ChangeNameAndDifficulty()
    {
        LevelName.GetComponent<TextMeshProUGUI>().text = eventSystem.currentSelectedGameObject.name;

        if (eventSystem.currentSelectedGameObject.name == "Level 1 : 1")
        {
            LevelDifficulty.GetComponent<TextMeshProUGUI>().text = "Difficulty: Easy";
        }
        if (eventSystem.currentSelectedGameObject.name == "Level 2 : 1")
        {
            LevelDifficulty.GetComponent<TextMeshProUGUI>().text = "Difficulty: Easy";
        }
        if (eventSystem.currentSelectedGameObject.name == "Level 2 : 2")
        {
            LevelDifficulty.GetComponent<TextMeshProUGUI>().text = "Difficulty: Medium";
        }
        if (eventSystem.currentSelectedGameObject.name == "Level 3 : 1")
        {
            LevelDifficulty.GetComponent<TextMeshProUGUI>().text = "Difficulty: Easy";
        }
        if (eventSystem.currentSelectedGameObject.name == "Level 3 : 2")
        {
            LevelDifficulty.GetComponent<TextMeshProUGUI>().text = "Difficulty: Medium";
        }
        if (eventSystem.currentSelectedGameObject.name == "Level 3 : 3")
        {
            LevelDifficulty.GetComponent<TextMeshProUGUI>().text = "Difficulty: Easy";
        }
        if (eventSystem.currentSelectedGameObject.name == "Level 4 : 1")
        {
            LevelDifficulty.GetComponent<TextMeshProUGUI>().text = "Difficulty: Medium";
        }
        if (eventSystem.currentSelectedGameObject.name == "Level 5 : 1")
        {
            LevelDifficulty.GetComponent<TextMeshProUGUI>().text = "Difficulty: Medium";
        }
        if (eventSystem.currentSelectedGameObject.name == "Level 5 : 2")
        {
            LevelDifficulty.GetComponent<TextMeshProUGUI>().text = "Difficulty: Hard";
        }
        if (eventSystem.currentSelectedGameObject.name == "Level 6 : 1")
        {
            LevelDifficulty.GetComponent<TextMeshProUGUI>().text = "Difficulty: Hard";
        }
    }
    private void ChangePictureOnWin()
    {
        if (GameAssets.instance.level11Win)
        {
            tick.GetComponent<Image>().enabled = true;
            Level11.GetComponent<Image>().enabled = false;
        }
        if (GameAssets.instance.level21Win)
        {
            tick1.GetComponent<Image>().enabled = true;
            Level21.GetComponent<Image>().enabled = false;
        }
        if (GameAssets.instance.level22Win)
        {
            tick2.GetComponent<Image>().enabled = true;
            Level22.GetComponent<Image>().enabled = false;
        }
        if (GameAssets.instance.level31Win)
        {
            tick3.GetComponent<Image>().enabled = true;
            Level31.GetComponent<Image>().enabled = false;
        }
        if (GameAssets.instance.level32Win)
        {
            tick4.GetComponent<Image>().enabled = true;
            Level32.GetComponent<Image>().enabled = false;
        }
        if (GameAssets.instance.level33Win)
        {
            tick5.GetComponent<Image>().enabled = true;
            Level33.GetComponent<Image>().enabled = false;
        }
        if (GameAssets.instance.level41Win)
        {
            tick6.GetComponent<Image>().enabled = true;
            Level41.GetComponent<Image>().enabled = false;
        }
        if (GameAssets.instance.level51Win)
        {
            tick7.GetComponent<Image>().enabled = true;
            Level51.GetComponent<Image>().enabled = false;
        }
        if (GameAssets.instance.level52Win)
        {
            tick8.GetComponent<Image>().enabled = true;
            Level52.GetComponent<Image>().enabled = false;
        }
        if (GameAssets.instance.level61Win)
        {
            tick9.GetComponent<Image>().enabled = true;
            Level61.GetComponent<Image>().enabled = false;
        }
    }
    private void SelectCorrcetLevelOnLoad()
    {
        if (GameAssets.instance.enableLevel1)
        {
            eventSystem.SetSelectedGameObject(Level11);
        }
        else if (GameAssets.instance.enableLevel2)
        {
            eventSystem.SetSelectedGameObject(Level21);
        }
        else if (GameAssets.instance.enableLevel3left)
        {
            eventSystem.SetSelectedGameObject(Level31);
        }
        else if (GameAssets.instance.enableLevel3right)
        {
            eventSystem.SetSelectedGameObject(Level32);
        }
        else if (GameAssets.instance.enableLevel4)
        {
            eventSystem.SetSelectedGameObject(Level41);
        }
        else if (GameAssets.instance.enableLevel5)
        {
            eventSystem.SetSelectedGameObject(Level51);
        }
        else if (GameAssets.instance.enableLevel6)
        {
            eventSystem.SetSelectedGameObject(Level61);
        }
    }
    private void EnableLevels()
    {
        Level11.GetComponent<Button>().interactable = GameAssets.instance.enableLevel1;

        if (GameAssets.instance.enableLevel3left)
        {
            Level31.GetComponent<Button>().interactable = GameAssets.instance.enableLevel3left;
            Level32.GetComponent<Button>().interactable = GameAssets.instance.enableLevel3left;
        }
        else if (GameAssets.instance.enableLevel3right)
        {
            Level32.GetComponent<Button>().interactable = GameAssets.instance.enableLevel3right;
            Level33.GetComponent<Button>().interactable = GameAssets.instance.enableLevel3right;
        }

        Level21.GetComponent<Button>().interactable = GameAssets.instance.enableLevel2;
        Level22.GetComponent<Button>().interactable = GameAssets.instance.enableLevel2;

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
        GameAssets.instance.enableLevel1 = false;
    }
    public void EnableLevel31And32()
    {
        GameAssets.instance.enableLevel3left = true;
        GameAssets.instance.enableLevel2 = false;
    }
    public void EnableLevel32And33()
    {
        GameAssets.instance.enableLevel3right = true;
        GameAssets.instance.enableLevel2 = false;

    }
    public void EnableLevel41()
    {
        GameAssets.instance.enableLevel4 = true;
        GameAssets.instance.enableLevel3left = false;
        GameAssets.instance.enableLevel3right = false;
    }
    public void EnableLevel51And52()
    {
        GameAssets.instance.enableLevel5 = true;
        GameAssets.instance.enableLevel4 = false;

    }
    public void EnableLevel61()
    {
        GameAssets.instance.enableLevel6 = true;
        GameAssets.instance.enableLevel5 = false;
    }
    public void DisableLevel61()
    {
        GameAssets.instance.enableLevel6 = false;
    }
    #endregion

    /// <summary>
    /// Starting the level on the correct button
    /// </summary>
    #region
    public void StartLevel1()
    {
        SceneManager.LoadScene(2);
        GameAssets.instance.level11Win = true;
        //StartCoroutine(GameObject.Find("LevelLoader").GetComponent<LevelLoader>().LoadLevel(2));
    }
    public void StartLevel21()
    {
        //StartCoroutine(GameObject.Find("LevelLoader").GetComponent<LevelLoader>().LoadLevel(5));
        SceneManager.LoadScene(2);
        GameAssets.instance.level21Win = true;

        GameAssets.instance.playersReady = true;
    }
    public void StartLevel22()
    {
        //StartCoroutine(GameObject.Find("LevelLoader").GetComponent<LevelLoader>().LoadLevel(7));
        GameAssets.instance.playersReady = true;
        SceneManager.LoadScene(2);
        GameAssets.instance.level22Win = true;

    }
    public void StartLevel31()
    {
        SceneManager.LoadScene(2);
        GameAssets.instance.level31Win = true;

        //StartCoroutine(GameObject.Find("LevelLoader").GetComponent<LevelLoader>().LoadLevel(9));
        GameAssets.instance.playersReady = true;
        //StartCoroutine(GameObject.Find("LevelLoader").GetComponent<LevelLoader>().LoadLevel(7));

    }
    public void StartLevel32()
    {
        SceneManager.LoadScene(2);
        GameAssets.instance.level32Win = true;

        //StartCoroutine(GameObject.Find("LevelLoader").GetComponent<LevelLoader>().LoadLevel(5));
        GameAssets.instance.playersReady = true;
        //StartCoroutine(GameObject.Find("LevelLoader").GetComponent<LevelLoader>().LoadLevel(9));

    }
    public void StartLevel33()
    {
        SceneManager.LoadScene(2);
        GameAssets.instance.level33Win = true;

        //StartCoroutine(GameObject.Find("LevelLoader").GetComponent<LevelLoader>().LoadLevel(5));
        GameAssets.instance.playersReady = true;

    }
    public void StartLevel41()
    {
        SceneManager.LoadScene(2);
        GameAssets.instance.level41Win = true;

        //StartCoroutine(GameObject.Find("LevelLoader").GetComponent<LevelLoader>().LoadLevel(5));
        GameAssets.instance.playersReady = true;


    }
    public void StartLevel51()
    {
        SceneManager.LoadScene(2);
        GameAssets.instance.level51Win = true;

        //StartCoroutine(GameObject.Find("LevelLoader").GetComponent<LevelLoader>().LoadLevel(5));
        GameAssets.instance.playersReady = true;

    }
    public void StartLevel52()
    {
        SceneManager.LoadScene(2);
        GameAssets.instance.level52Win = true;

        //StartCoroutine(GameObject.Find("LevelLoader").GetComponent<LevelLoader>().LoadLevel(5));
        GameAssets.instance.playersReady = true;

    }
    public void StartLevel61()
    {
        SceneManager.LoadScene(2);
        GameAssets.instance.level61Win = true;

        //StartCoroutine(GameObject.Find("LevelLoader").GetComponent<LevelLoader>().LoadLevel(5));
        GameAssets.instance.playersReady = true;

    }
    #endregion
}
