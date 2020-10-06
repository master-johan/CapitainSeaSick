using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    Material material;

    private void Start()
    {
        material = GetComponent<Renderer>().material;
    }

    private void Update()
    {
      
    }
    private void OnA()
    {
        material.color = Color.black;
           
    }

    private void OnSpace()
    {
       
    }

}
