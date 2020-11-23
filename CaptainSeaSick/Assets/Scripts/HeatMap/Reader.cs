using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Reader : MonoBehaviour
{
    Gradient gradient;
    GradientColorKey[] colorKey;
    GradientAlphaKey[] alphaKey;
    string[] lines;

    public GameObject g;

    private void Start()
    {
        gradient = new Gradient();
        

        // Populate the color keys at the relative time 0 and 1 (0 and 100%)
        colorKey = new GradientColorKey[2];
        colorKey[0].color = Color.blue;
        colorKey[0].time = 0.0f;
        colorKey[1].color = Color.red;
        colorKey[1].time = 1.0f;

        // Populate the alpha  keys at relative time 0 and 1  (0 and 100%)
        alphaKey = new GradientAlphaKey[2];
        alphaKey[0].alpha = 0.5f;
        alphaKey[0].time = 0.0f;
        alphaKey[1].alpha = 0.5f;
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
        lines = File.ReadAllLines(@datapath);

        Grid grid = new Grid(14, 6, 5, new Vector3(-50, 10, -5));


        Vector3 meshSize = g.GetComponent<MeshRenderer>().bounds.size;
        Vector3 localScale = g.transform.localScale;
        Vector3 offset = new Vector3(meshSize.x * localScale.x, 0, meshSize.y * localScale.z);

        for (int y = 0; y < grid.gridArray.GetLength(1); y++)
        {
            string[] splitLines = lines[6 - y].Split(' ');
            for (int x = 0; x < grid.gridArray.GetLength(0); x++)
            {
                grid.SetValue(x, y, int.Parse(splitLines[x]));
                Vector3 planePos = new Vector3(x * grid.cellSize, 0, y * grid.cellSize) + grid.orginPos;
                GameObject gb = Instantiate(g,planePos + offset , Quaternion.identity);
                gb.GetComponent<Renderer>().material.color = gradient.Evaluate(grid.gridArray[x,y] * 0.1f);
                
            }
        }
    }
}
