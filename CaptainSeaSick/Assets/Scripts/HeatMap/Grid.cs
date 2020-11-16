using CodeMonkey.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    private float cellSize;

    private int width;
    private int height;
    Vector3 orginPos;
    private float[,] gridArray;
    private TextMesh[,] debugTextArray;
    public Grid(int width, int height, float cellSize, Vector3 orginPos)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;
        this.orginPos = orginPos; 

        gridArray = new float[width, height];
        debugTextArray = new TextMesh[width, height];

        Debug.Log(width + "  " + height);

        for (int x = 0; x < gridArray.GetLength(0); x++)
        {
            for (int z = 0; z < gridArray.GetLength(1); z++)
            {
                debugTextArray[x, z] = UtilsClass.CreateWorldText(gridArray[x, z].ToString(), null, GetWorldPosition(x, z) + new Vector3(cellSize,0, cellSize) * 0.5f, 20, Color.white, TextAnchor.MiddleCenter);
                Debug.DrawLine(GetWorldPosition(x, z), GetWorldPosition(x, z + 1), Color.white, 100f);
                Debug.DrawLine(GetWorldPosition(x, z), GetWorldPosition(x + 1, z), Color.white, 100f);
            }
        }

        Debug.DrawLine(GetWorldPosition(width, 0), GetWorldPosition(width, height), Color.white, 100f);
        Debug.DrawLine(GetWorldPosition(0, height), GetWorldPosition(width, height), Color.white, 100f);

        SetValue(2, 1, 56);
    }

    private Vector3 GetWorldPosition(int x, int z)
    {
        return new Vector3(x, 0, z) * cellSize + orginPos;
    }

    public void GetXZ(Vector3 worldPosition, out int x, out int z)
    {
        x = Mathf.FloorToInt((worldPosition - orginPos).x / cellSize);
        z = Mathf.FloorToInt((worldPosition - orginPos).z / cellSize);
    }

    public void SetValue(int x, int z, float value)
    {
        if (x >= 0 && z >= 0 && x < width && z < height)
        {
            gridArray[x, z] += value;
            debugTextArray[x, z].text = gridArray[x, z].ToString("0.0");
        }
    }
    private void SetValue(int x, int z)
    {
        if (x >= 0 && z >= 0 && x < width && z < height)
        {
            gridArray[x, z]++;
            debugTextArray[x, z].text = gridArray[x, z].ToString("f1");
        }
    }


    public void SetValue(Vector3 worldPosition, float value)
    {
        int x, z;
        GetXZ(worldPosition, out x, out z);
        SetValue(x, z, value);
    }
}
