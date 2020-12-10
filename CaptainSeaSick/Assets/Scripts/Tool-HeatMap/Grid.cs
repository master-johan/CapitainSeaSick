using CodeMonkey.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
[Serializable]
public enum HeatMapLayer
{
    playerPos,
    swordUse,
    enemyPos,
    canonFire,
    playerDamage
}
public class Grid 
{
    public float cellSize;
    public float[, ,] gridArray;
    public int width;
    public int height;
    public int layer;
    public Vector3 orginPos;
    public bool showText = true;
    
    private TextMesh[,] debugTextArray;
    public Grid(int width, int height, int layer,  float cellSize, Vector3 orginPos)
    {
        this.width = width;
        this.height = height;
        this.layer = layer;
        this.cellSize = cellSize;
        this.orginPos = orginPos;

        gridArray = new float[width, height, layer];
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
                debugTextArray[x, z] = UtilsClass.CreateWorldText(gridArray[x, z, (int)HeatMapLayer.playerPos].ToString(), null, GetWorldPosition(x, z) + new Vector3(cellSize, 50, cellSize) * 0.5f, 10, null, TextAnchor.MiddleCenter);
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

    public void SetValue(int x, int z, int layer, float value)
    {
        if (x >= 0 && z >= 0 && x < width && z < height)
        {
            gridArray[x, z, layer] += value;
            debugTextArray[x, z].text = gridArray[x, z, layer].ToString("0");
        }
    }
    private void SetValue(int x, int z)
    {
        if (x >= 0 && z >= 0 && x < width && z < height)
        {
            gridArray[x, z, layer]++;
            debugTextArray[x, z].text = gridArray[x, z, layer].ToString("0");
        }
    }
    public void ResetValues()
    {
        for (int i = 0; i < gridArray.GetLength(0); i++)
        {
            for (int j = 0; j < gridArray.GetLength(1); j++)
            {
                for (int k = 0; k < gridArray.GetLength(2); k++)
                {
                    gridArray[i, j, k] = 0;
                }
            }
        }
    }


    public void SetValue(Vector3 worldPosition, int layer, float value)
    {
        int x, z;
        GetXZ(worldPosition, out x, out z);
        SetValue(x, z, layer, value);
    }

    public string ToString(string scene, string levelName, int players)
    {
        StringBuilder s = new StringBuilder();
        HeatMapLayer currentLayer = 0;
        s.AppendLine("GridSize: " + gridArray.GetLength(0) + ", " +gridArray.GetLength(1) + "#" + scene + "#" + levelName +"#" + players);
        for (int layer = 0; layer < gridArray.GetLength(2) ; layer++)
        {
            currentLayer = (HeatMapLayer)layer;
            s.AppendLine(currentLayer.ToString());
            for (int y = gridArray.GetLength(1) - 1; y >= 0; y--)
            {
                for (int x = 0; x < gridArray.GetLength(0); x++)
                {
                    s.Append((Math.Ceiling(gridArray[x, y, layer])).ToString() + " ");
                }
                s.AppendLine();
            }
           
        }
     
        s.Append(";");
        return s.ToString();
    }
}
