using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind_Pointer_Functionality : MonoBehaviour
{

    public GameObject windGenerator;

    
    // Start is called before the first frame update
    void Start()
    {
        windGenerator = GameObject.Find("WindGenerator");
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 targetDirection =  - transform.position;

        Vector3 newDirection = Vector3.RotateTowards(transform.forward, windGenerator.GetComponent<Wind_Functionality>().windDirection, 1, 0.0f);

        transform.rotation = Quaternion.LookRotation(newDirection);
    }
}
