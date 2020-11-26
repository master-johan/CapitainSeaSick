using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyCannonballScript : MonoBehaviour
{
    
    public bool isHit;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ship")
        {
            isHit = true;
           
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Ship")
        {
            isHit = true;
        }
    }
}
