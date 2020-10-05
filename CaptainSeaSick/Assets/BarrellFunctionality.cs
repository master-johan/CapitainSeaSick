using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class BarrellFunctionality : MonoBehaviour
{
    Vector3 direction;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        direction = new Vector3(0, 0, -1);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, -1));
        rb.transform.position += direction * (Time.deltaTime * 7);
    }
}
