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
}
