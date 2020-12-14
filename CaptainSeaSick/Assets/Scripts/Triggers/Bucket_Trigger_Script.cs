using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bucket_Trigger_Script : MonoBehaviour
{
    Rigidbody rb;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame

    private void OnTriggerEnter(Collider other)
    {
        if (player == null)
        {
            if (other.tag == "Player")
            {
                player = other.gameObject;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" && player == other.gameObject)
        {
            player = null;
        }
    }
}
