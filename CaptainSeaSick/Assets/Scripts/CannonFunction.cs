using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonFunction : MonoBehaviour
{
    List<GameObject> gameobjects = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        var transforms = GetComponentsInChildren<Transform>();
        foreach (Transform child in transforms)
        {
            GameObject obj = child.gameObject;
            gameobjects.Add(obj);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
