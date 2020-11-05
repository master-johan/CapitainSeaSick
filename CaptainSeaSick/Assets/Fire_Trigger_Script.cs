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
            Debug.Log("hej");
            gameObject.SetActive(false);
        }
        else if (other.tag == "Player")
        {
            if(!other.isTrigger)
            {
                other.GetComponent<PlayerManagement>().PlayerRespawn();
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
    }

}
