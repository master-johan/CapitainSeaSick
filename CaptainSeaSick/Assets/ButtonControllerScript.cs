using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonControllerScript : MonoBehaviour
{

    float timer = 6;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if(timer <= 0)
        {
            GameObject.Find("ReturnButton").GetComponent<Button>().interactable = true;
        }
    }

    public void ReturnToMainMenu()
    {
        GameObject.Find("LevelLoader").GetComponent<LevelLoader>().LoadMainMenu();
    }
}
