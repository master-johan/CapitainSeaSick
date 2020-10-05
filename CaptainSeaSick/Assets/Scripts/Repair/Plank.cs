using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plank : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isPickedUp;
    public bool isInRadius;

    private Vector3 forwardPos;
    // Start is called before the first frame update
    void Start()
    {
        isPickedUp = false;
    }

    // Update is called once per frame
    void Update()
    {


    }
    private void OnCollisionEnter(Collision collision)
    {
        //if (collision.gameObject.name == "Plane" | collision.gameObject.name == "Plane(Clone)")
        //{
        //    Destroy(gameObject);
        //}
        
    }

}
