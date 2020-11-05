using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerManagement : MonoBehaviour
{
    [SerializeField]
    GameObject hatPos;
    [SerializeField]
    GameObject hat;
    Color color1, color2, color3, color4;

    public static int playerIndex = 1;
    GameObject playerInputManager, controllerMenuSystem;
    Vector3 spawnPos;

    bool once; // Only for show

    // Start is called before the first frame update
    void Start()
    {
        playerInputManager = GameObject.FindGameObjectWithTag("PlayerInputManager");
        controllerMenuSystem = GameObject.FindGameObjectWithTag("ControllerMenuSystem");



        GenerateColors();
        CopyMeshAndCreate(GameAssets.instance.hatPrefab, hatPos);
        SetColor(playerIndex);
        transform.position = spawnPos + playerInputManager.transform.position;
        playerIndex++;
    }

    private void SetColor(int playerIndex)
    {
        Color colorToSet;
        if (playerIndex == 1)
        {
            colorToSet = color1;
            spawnPos = GameAssets.instance.spawnPosP1;

        }
        else if (playerIndex == 2)
        {
            colorToSet = color2;
            spawnPos = GameAssets.instance.spawnPosP2;
        }
        else if (playerIndex == 3)
        {
            colorToSet = color3;
            spawnPos = GameAssets.instance.spawnPosP3;
        }
        else
        {
            colorToSet = color4;
            spawnPos = GameAssets.instance.spawnPosP4;
        }
        GetComponent<Outline>().OutlineColor = colorToSet;
        hatPos.GetComponent<Renderer>().material.color = colorToSet;
    }



    // Update is called once per frame
    void Update()
    {
        //Doesnt destory the player and sets the correct spawn position in the ScaveningScene.
        DontDestroyOnLoad(gameObject);
        if (ControllerMenuJoinScript.playerReady)
        {
            controllerMenuSystem.SetActive(false);

        }
        if (SceneManager.GetActiveScene().buildIndex == 2 && !once)
        {
            playerInputManager = GameObject.FindGameObjectWithTag("PlayerInputManager");
            transform.position = spawnPos + playerInputManager.transform.position;
            //transform.gameObject.GetComponent<PlayerMovementUsingForce>().pickedUp = false;
            once = true;
        }
    }

    private void CopyMeshAndCreate(GameObject orignal, GameObject destination)
    {
        Mesh hatMesh = orignal.GetComponent<MeshFilter>().sharedMesh;
        Mesh mesh2 = Instantiate(hatMesh);
        destination.GetComponent<MeshFilter>().sharedMesh = mesh2;
        destination.GetComponent<Transform>().localScale = hat.transform.localScale;
    }

    private void GenerateColors()
    {
        color1 = Color.blue;
        color2 = Color.red;
        color3 = Color.green;
        color4 = Color.yellow;
    }
    public Vector3 PlayerRespawn()
    {
        return transform.position = spawnPos + playerInputManager.transform.position;
    }
}
