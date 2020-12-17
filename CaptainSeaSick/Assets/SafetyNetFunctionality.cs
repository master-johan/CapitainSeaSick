using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafetyNetFunctionality : MonoBehaviour
{
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
        if(other.tag == "PickableObject" || other.tag == "Player")
        {
            int random = Random.Range(0, 2);

            if (random == 0)
            {
                other.transform.position = new Vector3(Random.Range(-5, 4), 4, Random.Range(-3, 3));           
            }
            else if (random == 1)
            {
                other.transform.position = new Vector3(Random.Range(-7, 4), 4, Random.Range(15, 21));              
            }

        }
        if (other.tag == "Player")
        {
           
            other.GetComponent<PlayerManagement>().PlayerShipRespawn();

        }
        else if (other.tag == "PickableObject")
        {
            other.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }
}
