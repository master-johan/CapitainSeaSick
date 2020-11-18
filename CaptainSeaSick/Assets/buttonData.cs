using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttonData : MonoBehaviour
{
    public string dataPath;
    Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
    }


    public void Inputs(string name, string path)
    {
        button.name = name;
        button.GetComponentInChildren<Text>().text = name;
        dataPath = path;

    }

    public void LoadData()
    {
        GameObject.Find("Reader").GetComponent<Reader>().ReadData(dataPath);
    }
}
