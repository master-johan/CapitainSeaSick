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

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);

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
            spawnPos = GameAssets.instance.spawnPositions[0];

        }
        else if (playerIndex == 2)
        {
            colorToSet = color2;
            spawnPos = GameAssets.instance.spawnPositions[1];
        }
        else if (playerIndex == 3)
        {
            colorToSet = color3;
            spawnPos = GameAssets.instance.spawnPositions[2];
        }
        else
        {
            colorToSet = color4;
            spawnPos = GameAssets.instance.spawnPositions[3];
        }
        GetComponent<Outline>().OutlineColor = colorToSet;
        hatPos.GetComponent<Renderer>().material.color = colorToSet;
    }



    // Update is called once per frame
    void Update()
    {
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
        color1 = Color.red;
        color2 = Color.blue;
        color3 = Color.green;
        color4 = Color.yellow;
    }
    public Vector3 PlayerScavRespawn()
    {
        GetComponent<PlayerActions>().ReleaseItem();
        GameObject.Find("Grid").GetComponent<GridTest>().grid.SetValue(new Vector3(transform.position.x,0,transform.position.z),(int)HeatMapLayer.playerDamage,1);
        return transform.position = GameAssets.instance.spawnScavPhase;
    }
}