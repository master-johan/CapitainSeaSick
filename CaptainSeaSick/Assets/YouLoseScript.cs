using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class YouLoseScript : MonoBehaviour
{
    public InputAction returnToMenu;
    bool once;
    // Start is called before the first frame update
    void Start()
    {
        returnToMenu.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        if(returnToMenu.triggered && !once)
        {
            once = true;
            Time.timeScale = 1;
            GameAssets.instance.ResetGameAssets();
            GameObject.Find("LevelLoader").GetComponent<LevelLoader>().LoadMainMenu();
        }
    }
}
