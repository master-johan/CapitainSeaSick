using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerManagement : MonoBehaviour
{
    [SerializeField]
    GameObject hatPos;
    [SerializeField]
    GameObject hat;
    Color color1,color2,color3,color4;

    static int playerIndex =1;
 
    // Start is called before the first frame update
    void Start()
    {
        GenerateColors();
        CopyMeshAndCreate(hat, hatPos);
        SetColor(playerIndex);
        playerIndex++;
    }

    private void SetColor(int playerIndex)
    {
        Color colorToSet;
        if (playerIndex == 1)
        {
            colorToSet = color1;
        }
        else if (playerIndex == 2 )
        {
            colorToSet = color2;
        }
        else if (playerIndex == 3)
        {
            colorToSet = color3;
        }
        else
        {
            colorToSet = color4;
        }

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
        color1 = Color.blue;
        color2 = Color.red;
        color3 = Color.green;
        color4 = Color.yellow;
    }
}
