using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RBmovement : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        rb.velocity = new Vector3(h, 0, v) * speed * Time.deltaTime; //Fungerar mer smooth 
    }
}
