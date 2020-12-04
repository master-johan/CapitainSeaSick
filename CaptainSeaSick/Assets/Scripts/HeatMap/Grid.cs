using CodeMonkey.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
[Serializable]
public class Grid 
{
    public float cellSize;
    public float[,] gridArray;
    public int width;
    public int height;
    public Vector3 orginPos;
    public bool showText = true;
    
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

        if (showText)
        {
            ShowTextAndLines(width, height, cellSize);
        }
        
    }

    private void ShowTextAndLines(int width, int height, float cellSize)
    {
        for (int x = 0; x < gridArray.GetLength(0); x++)
        {
            for (int z = 0; z < gridArray.GetLength(1); z++)
            {
                debugTextArray[x, z] = UtilsClass.CreateWorldText(gridArray[x, z].ToString(), null, GetWorldPosition(x, z) + new Vector3(cellSize, 50, cellSize) * 0.5f, 20, null, TextAnchor.MiddleCenter);
               // Debug.DrawLine(GetWorldPosition(x, z), GetWorldPosition(x, z + 1), Color.white, 100f);
               // Debug.DrawLine(GetWorldPosition(x, z), GetWorldPosition(x + 1, z), Color.white, 100f);
            }
        }

       // Debug.DrawLine(GetWorldPosition(width, 0), GetWorldPosition(width, height), Color.white, 100f);
       // Debug.DrawLine(GetWorldPosition(0, height), GetWorldPosition(width, height), Color.white, 100f);
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

    public override string ToString()
    {
        StringBuilder s = new StringBuilder();

        s.AppendLine("GridSize: " + gridArray.GetLength(0) + ", " +gridArray.GetLength(1));
        for (int y = gridArray.GetLength(1)-1; y >= 0 ; y--)
        {
            for (int x = 0; x < gridArray.GetLength(0); x++)
            {
                s.Append(((int)gridArray[x, y]).ToString() + " ");
            }
            s.AppendLine();
        }
        s.Append(";");
        return s.ToString();
    }
}
