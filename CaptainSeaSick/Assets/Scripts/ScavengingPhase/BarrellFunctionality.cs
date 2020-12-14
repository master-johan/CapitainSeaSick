using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;

public class BarrellFunctionality : MonoBehaviour
{
    Vector3 direction;
    Rigidbody rb;
    GameObject parent;

    void Start()
    {
        parent = transform.parent.gameObject;
        rb = GetComponent<Rigidbody>();
        direction = parent.GetComponent<BarrellSpawner>().targetObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Rotate the barrel when rolling and move the barrell in the direction-vector.
        transform.Rotate(new Vector3(0, 0, -1));

        transform.position = Vector3.MoveTowards(transform.position, direction, 5 * Time.deltaTime);
        // rb.transform.position += direction * (Time.deltaTime * 7);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (!other.isTrigger)
            {
                other.GetComponent<PlayerManagement>().PlayerScavRespawn();
                other.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
        }
    }
}
