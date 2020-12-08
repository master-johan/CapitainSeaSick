using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffsetScript : MonoBehaviour
{
    public float offsetX, offsetYMultiplier;
    public float offsetY;


    private void Start()
    {
        offsetY =  transform.localScale.y * offsetYMultiplier;
        
    }
    private void Update()
    {

      

    }
    
    public float[] GetOffsets()
    {
        float[] offsetArray = new float[2];
        offsetArray[0] = offsetX;
        offsetY = transform.localScale.y * offsetYMultiplier;
        offsetArray[1] = offsetY;
        return offsetArray;
    }
}
