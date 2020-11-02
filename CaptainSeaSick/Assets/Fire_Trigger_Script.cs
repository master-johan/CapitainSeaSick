using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire_Trigger_Script : MonoBehaviour
{
    // Start is called before the first frame update

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Bucket")
        {
            gameObject.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
    }
}
