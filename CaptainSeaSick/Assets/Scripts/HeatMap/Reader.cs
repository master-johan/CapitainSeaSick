using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Reader : MonoBehaviour
{
    string[] lines;



    public void ReadData(string datapath)
    {
        lines = File.ReadAllLines(@datapath);

        Grid grid = new Grid(14, 6, 5, new Vector3(-50, 10, -5));

        int temp = 0;

        for (int y = 0; y < grid.gridArray.GetLength(1); y++)
        {
            string[] splitLines = lines[6-y].Split(' ');
            for (int x = 0; x < grid.gridArray.GetLength(0); x++)
            {
                grid.SetValue(x, y, int.Parse(splitLines[x]));
            }
            temp++;
        }
    }
}
