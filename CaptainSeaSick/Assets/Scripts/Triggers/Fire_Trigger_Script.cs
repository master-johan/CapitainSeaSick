using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire_Trigger_Script : MonoBehaviour
{
    private GameObject scavManager;
    // Start is called before the first frame update

    private void Start()
    {
        scavManager = GameObject.Find("ScavengingManager");
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Bucket")
        {
            GameObject.Find("Water").SetActive(false);
            gameObject.SetActive(false);
        }
        else if (other.tag == "Player")
        {
            if(!other.isTrigger)
            {
                other.GetComponent<PlayerManagement>().PlayerScavRespawn();
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
    }

}
