using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class SnapshotCamera : MonoBehaviour
{
    GridTest gridTest;
    Camera snapCam;
    int resWidth = 256;
    int resHeight =  256;
    

    void Awake()
    {
        snapCam = GetComponent<Camera>();
        if (snapCam.targetTexture == null)
        {
            snapCam.targetTexture = new RenderTexture(resWidth, resHeight, 24);
        }
        else
        {
            resWidth = snapCam.targetTexture.width;
            resHeight = snapCam.targetTexture.height;
        }
        //snapCam.gameObject.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        gridTest = GameObject.Find("Testing").GetComponent<GridTest>();
    }

    // Update is called once per frame
    void Update()
    {
   
    }

    public void CallTakeSnapShot()
    {
        Texture2D snapshot = new Texture2D(resWidth, resHeight, TextureFormat.RGB24, false);
        snapCam.Render();
        RenderTexture.active = snapCam.targetTexture;
        snapshot.ReadPixels(new Rect(0, 0, resWidth, resHeight), 0, 0);
        byte[] bytes = snapshot.EncodeToPNG();
        string fileName = SnapshotName();
        System.IO.File.WriteAllBytes(fileName, bytes);
        Debug.Log("Shooting wild with the snapshot");
        gridTest.PrintData();
        //snapCam.gameObject.SetActive(false);
    }

    void LateUpdate()
    {
        if (snapCam.gameObject.activeInHierarchy)
        {
  

        }   
    }

    private string SnapshotName()
    {
        return string.Format("{0}/Snapshot/snap_{1}x{2}_{3}.png",
            Application.dataPath,
            resWidth,
            resHeight,
            System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
    }
}
