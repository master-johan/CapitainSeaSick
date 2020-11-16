using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water_Paralax : MonoBehaviour
{
    Vector3 startPos;
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(10, 0, 0) * Time.deltaTime;
    }
}
