﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;

public class ControllerMenuJoinScript : MonoBehaviour
{
    public GameObject infoManager;
    public TextMeshProUGUI player1Text, player2Text, player3Text, player4Text;
    private GameObject playerInputManager;
    private GameObject menuSystemController;
    public InputSystemUIInputModule inputSystem;

    static public bool playerReady;
    
    void Start()
    {
        playerInputManager = GameObject.FindGameObjectWithTag("PlayerInputManager");
        menuSystemController = GameObject.FindGameObjectWithTag("ControllerMenuSystem");
    }

    // Update is called once per frame
    void Update()
    {
        var index = playerInputManager.GetComponent<PlayerInputManager>().playerCount;

        if (index == 1)
        {
            player1Text.text = "Connected";
        }
        else if (index == 2)
        {
            player2Text.text = "Connected";
        }
        else if (index == 3)
        {
            player3Text.text = "Connected";
        }
        else if (index == 4)
        {
            player4Text.text = "Connected";
        }


        if(inputSystem.submit.action.triggered)
        {
            GameAssets.instance.playersReady = true;
            
            infoManager.SetActive(true);
        }
    }

}
