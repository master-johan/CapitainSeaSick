using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelMapManager : MonoBehaviour
{
    GameObject Level21, Level22;
    GameObject Level31, Level32 ,Level33;
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
        
    }

    public void EnableLevel2()
    {
        Level21.GetComponent<Button>().interactable = true;

        SceneManager.LoadScene(5);
        Level22.GetComponent<Button>().interactable = true;
    }

    public void EnableLevel31And32()
    {
        Level31.GetComponent<Button>().interactable = true;
        Level32.GetComponent<Button>().interactable = true;
    }
    public void EnableLevel32And33()
    {
        Level32.GetComponent<Button>().interactable = true;
        Level33.GetComponent<Button>().interactable = true;
    }
    public void EnableLevel41()
    {
        Level41.GetComponent<Button>().interactable = true;
    }
    public void EnableLevel51And52()
    {
        Level51.GetComponent<Button>().interactable = true;
        Level52.GetComponent<Button>().interactable = true;
    }
    public void EnableLevel61()
    {
        Level61.GetComponent<Button>().interactable = true;
    }
    public void StartLevel1()
    {
        GameObject.Find("LevelLoader").GetComponent<LevelLoader>().LoadNextLevel();
    }

}
