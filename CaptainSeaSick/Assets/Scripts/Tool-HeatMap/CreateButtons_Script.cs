using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class CreateButtons_Script : MonoBehaviour
{
    public GameObject ButtonPrefab;
    private void Start()
    {
        ScrollRect scrollRect = GetComponent<ScrollRect>();

        string[] files = Directory.GetFiles(Application.dataPath + "/Snapshot", "*json"); 

        for (int i = 0; i < files.Length; i++)
        {
            string[] name = files[i].Split('\\');
            GameObject gameObject = Instantiate(ButtonPrefab, scrollRect.transform);
            buttonData data = gameObject.GetComponent<buttonData>();
            data.Inputs(name[name.Length-1].Split('.')[0],files[i]);
        }
    }
}
