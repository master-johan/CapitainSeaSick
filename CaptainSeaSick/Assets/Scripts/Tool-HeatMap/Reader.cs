using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class Reader : MonoBehaviour
{
    Gradient gradient;
    GradientColorKey[] colorKey;
    GradientAlphaKey[] alphaKey;
    string[] lines;

    Grid grid;
    List<GameObject> planeList;
    public GameObject Ship;
    public GameObject Scav3;
    public GameObject g;

    public TextMeshProUGUI levelinfo;

    private void Start()
    {
        planeList = new List<GameObject>();
        gradient = new Gradient();

        grid = new Grid(22, 10, 5, 3, new Vector3(-50, 10, -5));

        // Populate the color keys at the relative time 0 and 1 (0 and 100%)
        colorKey = new GradientColorKey[2];
        colorKey[0].color = Color.yellow;
        colorKey[0].time = 0.0f;
        colorKey[1].color = Color.red;
        colorKey[1].time = 1.0f;

        // Populate the alpha  keys at relative time 0 and 1  (0 and 100%)
        alphaKey = new GradientAlphaKey[2];
        alphaKey[0].alpha = 0.7f;
        alphaKey[0].time = 0.0f;
        alphaKey[1].alpha = 0.7f;
        alphaKey[1].time = 1.0f;

        gradient.SetKeys(colorKey, alphaKey);

        // What's the color at the relative time 0.25 (25 %) ?
        Debug.Log(gradient.Evaluate(1.0f));

        //g.GetComponent<Renderer>().material.color = gradient.Evaluate(.9f);
        //g.transform.Rotate(new Vector3(-90, 0, 0));
        //for (int i = 0; i < 100; i++)
        //{
        //    GameObject gb = Instantiate(g, new Vector3(0, 2 * i, 0), g.transform.rotation);
        //    gb.GetComponent<Renderer>().material.color = gradient.Evaluate(i * .01f);


        //}
    }

    public void ReadData(string datapath)
    {
        ResetGrid();

        lines = File.ReadAllLines(@datapath);

        int[] maxValue = new int[grid.gridArray.GetLength(2)];

        Vector3 meshSize = g.GetComponent<MeshRenderer>().bounds.size;
        Vector3 offset = new Vector3(meshSize.x * 0.5f, 0, meshSize.y * 0.5f);

        maxValue = CountMaxValue(maxValue);
        WhatScene();

        for (int y = 0; y < grid.gridArray.GetLength(1); y++)
        {
            string[] splitLines = lines[10 - y].Split(' ');
            for (int x = 0; x < grid.gridArray.GetLength(0); x++)
            {
                //grid.SetValue(x, y, int.Parse(splitLines[x]));
                Vector3 planePos = new Vector3(x * grid.cellSize, 0, y * grid.cellSize) + grid.orginPos;
                GameObject gb = Instantiate(g, planePos + offset, Quaternion.identity);
                planeList.Add(gb);

                //if (grid.gridArray[x,y] > 0)
                //{
                //    gb.GetComponent<Renderer>().material.color = gradient.Evaluate(grid.gridArray[x, y] / maxValue);
                //}
                //else
                //{
                //    gb.GetComponent<Renderer>().material.color = new Color(0.5f, 0.5f, 0.5f, 0.5f);
                //}
            }
        }
    }
    public int[] CountMaxValue(int[] max)
    {
        for (int layer = 0; layer < grid.gridArray.GetLength(2); layer++)
        {
            for (int y = 0; y < grid.gridArray.GetLength(1); y++)
            {
                string[] splitLines;

                splitLines = lines[(layer + 1) * 11 - y].Split(' ');

                //if (y == 0)
                //{
                //    splitLines = lines[11 * (layer + 1) - y].Split(' ');

                //}
                //else
                //{
                //    splitLines = lines[10 * (layer + 1) - y].Split(' ');
                //}
                for (int x = 0; x < splitLines.GetLength(0) -1 /*grid.gridArray.GetLength(0)*/; x++)
                {
                    if (splitLines.GetLength(0) > 1 )
                    {
                        if (int.Parse(splitLines[x]) > max[layer])
                        {
                            max[layer] = int.Parse(splitLines[x]);
                        }
                    }
                    else
                    {

                    }
                }
            }
        }
       
        return max;
    }
    public void ResetGrid()
    {
        grid.ResetValues();
        for (int i = 0; i < planeList.Count; i++)
        {
            Destroy(planeList[i]);
        }
        planeList.Clear();
    }
    public void WhatScene()
    {
        string[] splitScene = lines[0].Split('#');
        if (splitScene[1] == "Scav")
        {
            Scav3.SetActive(true);
            Ship.SetActive(false);
        }
        else
        {
            Scav3.SetActive(false);
            Ship.SetActive(true);
        }
        levelinfo.text = splitScene[2];
    }
}
