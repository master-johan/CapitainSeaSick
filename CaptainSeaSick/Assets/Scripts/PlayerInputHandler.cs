using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    private PlayerInput playerInput;
    private PlayerInputManager playerInputManager;
    public GameObject player1, player2, player3, player4;

    
    // Start is called before the first frame update
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        playerInputManager = GetComponent<PlayerInputManager>();
      
    }

    // Update is called once per frame
    void Update()
    {
        var index = playerInputManager.playerCount;

        if(index == 0)
        {
            playerInputManager.playerPrefab = player1;
        }
        else if (index == 1)
        {
            playerInputManager.playerPrefab = player2;
        }
        else if (index == 2)
        {
            playerInputManager.playerPrefab = player3;
        }
        else if (index == 3)
        {
            playerInputManager.playerPrefab = player4;
        }
    }

}
