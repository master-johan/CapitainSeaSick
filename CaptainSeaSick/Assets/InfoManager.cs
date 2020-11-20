using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;

public class InfoManager : MonoBehaviour
{
    public int Index;
    public TextMeshProUGUI infoText;
    public bool infoTextRunning;
    public GameObject image ;
    public InputAction click;

    Sprite sprite;
    // Start is called before the first frame update
    void Start()
    {
        click.Enable();
        infoTextRunning = true;
        Index = 0;
         ChangeImage();

    }

    // Update is called once per frame
    void Update()
    {

        if(click.triggered)
        {
            Continue();
        }

        PauseGame();
    }

    public void Continue()
    {
        Index++;
        ChangeImage();

    }
    public void ChangeImage()
    {
        GameAssets.instance.gameIsPaused = true;
        if (Index == 0)
        {
            image.GetComponent<Image>().sprite = GameAssets.instance.infoImages[Index];
            infoText.text = "In the bottom of the screen you have the timeline, where you can see whats coming up";
        }
        else if (Index == 1)
        {
            image.GetComponent<Image>().sprite = GameAssets.instance.infoImages[Index];
            infoText.text = "To be able to see what is coming up you are able to climb the mast and look ahead";
        }
        else if (Index == 2)
        {
            image.GetComponent<Image>().sprite = GameAssets.instance.infoImages[Index];
            infoText.text = "Then your timeline will change to icons depending on what obstacles that is coming up";
        }
        else if (Index == 3)
        {
            image.GetComponent<Image>().sprite = GameAssets.instance.infoImages[Index];
            infoText.text = "One obstacle can be cliffs ";
        }
        else if (Index == 4)
        {
            image.GetComponent<Image>().sprite = GameAssets.instance.infoImages[Index];
            infoText.text = "If you use the Captains wheel you are able to steer the boat away from the cliffs";
        }
        else if (Index == 5)
        {
            image.GetComponent<Image>().sprite = GameAssets.instance.infoImages[Index];
            infoText.text = "If the boat hit the cliffs the boat will take damage and a leak will spawn on the boat";
        }
        else if (Index == 6)
        {
            image.GetComponent<Image>().sprite = GameAssets.instance.infoImages[Index];
            infoText.text = "If there is a leak on the boat some one from the crew have to get a plank from the plank container and repair the leak";
        }
        else if (Index == 7)
        {
            image.GetComponent<Image>().sprite = GameAssets.instance.infoImages[Index];
            infoText.text = "The red indicators that spawn at sea shows you that there is an attacking enemy ship in that direction";
        }
        else if (Index == 8)
        {
            image.GetComponent<Image>().sprite = GameAssets.instance.infoImages[Index];
            infoText.text = "To defeat the enemy you have to move a cannon into the right position, load it and fire a cannonball at it";
        }
        else
        {
            GameAssets.instance.gameIsPaused = false;
            gameObject.SetActive(false);
            

        }
    }
    void PauseGame()
    {
        if (GameAssets.instance.gameIsPaused)
        {
            // Time.timeScale = 0f;
            GameAssets.instance.PauseGame();
        }
        else
        {
            GameAssets.instance.UnPauseGame();
            GameObject.Find("CountDown").GetComponentInChildren<Countdown_Script>().StartCountDown();
        }
    }
}