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
    private int[,] gridArray;
    private TextMesh[,] debugTextArray;
    public Grid(int width, int height, float cellSize)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;

        gridArray = new int[width, height];
        debugTextArray = new TextMesh[width, height];

        Debug.Log(width + "  " + height);

        for (int x = 0; x < gridArray.GetLength(0); x++)
        {
            for (int y = 0; y < gridArray.GetLength(1); y++)
            {
                debugTextArray[x,y] = UtilsClass.CreateWorldText(gridArray[x, y].ToString(), null, GetWorldPosition(Mathf.FloorToInt(transform.position.x) + x, Mathf.FloorToInt(transform.position.y) + y) + new Vector3(cellSize,cellSize) * 0.5f, 20, Color.white, TextAnchor.MiddleCenter);
                Debug.DrawLine(GetWorldPosition(Mathf.FloorToInt(transform.position.x) + x, Mathf.FloorToInt(transform.position.y) + y), GetWorldPosition(Mathf.FloorToInt(transform.position.x) + x, Mathf.FloorToInt(transform.position.y) + y + 1), Color.white, 100f);
                Debug.DrawLine(GetWorldPosition(Mathf.FloorToInt(transform.position.x) + x, Mathf.FloorToInt(transform.position.y) + y), GetWorldPosition(Mathf.FloorToInt(transform.position.x) + x + 1, Mathf.FloorToInt(transform.position.y) + y), Color.white, 100f);
            }
        }

        Debug.DrawLine(GetWorldPosition(width, (Mathf.FloorToInt(transform.position.y))), GetWorldPosition(width, height), Color.white, 100f);
        Debug.DrawLine(GetWorldPosition((Mathf.FloorToInt(transform.position.x)), height), GetWorldPosition(width, height), Color.white, 100f);

        SetValue(2, 1, 56);
    }

    private Vector3 GetWorldPosition(int x, int y)
    {
        return new Vector3(x, y) * cellSize;
    }
    
    private void GetXY(Vector3 worldPosition, out int x, out int y)
    {
        x = Mathf.FloorToInt(worldPosition.x / cellSize);
        y = Mathf.FloorToInt(worldPosition.y / cellSize);
    }

    public void SetValue(int x, int y, int value)
    {
        if (x >= 0 && y >= 0 && x < width && y < height)
        {
            gridArray[x, y] = value;
            debugTextArray[x, y].text = gridArray[x, y].ToString();
        }
    }

    public void SetValue(Vector3 worldPosition, int value)
    {
        int x, y;
        GetXY(worldPosition, out x, out y);
        SetValue(x, y, value);
    }
}
