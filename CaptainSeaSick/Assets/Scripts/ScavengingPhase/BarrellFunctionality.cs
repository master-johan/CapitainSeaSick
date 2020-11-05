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
        //The direction for the barrell to roll in (only downwards in the z-axis)
        direction = new Vector3(0, 0, -1);
    }

    // Update is called once per frame
    void Update()
    {
        //Rotate the barrel when rolling and move the barrell in the direction-vector.
        transform.Rotate(new Vector3(0, 0, -1));
        rb.transform.position += direction * (Time.deltaTime * 7);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (!other.isTrigger)
            {
                other.GetComponent<PlayerManagement>().PlayerRespawn();
            }
        }
    }
}
