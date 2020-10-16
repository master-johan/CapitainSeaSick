using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    Rigidbody rb;
    //float speed;
    [SerializeField] float speed;
    // Start is called before the first frame update
    void Start()
    {
        //speed = 10f;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float movHor = Input.GetAxis("Horizontal");
        float movVer = Input.GetAxis("Vertical");
        rb.velocity = new Vector3(movHor * speed, rb.velocity.y, movVer * speed);
    }
}
