using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowNest_Trigger_Script : MonoBehaviour
{
    public GameObject teleportTarget;
    GameObject player, playerInZone;
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
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerActions>().SetFocus(transform.gameObject, 0, 0);
            Debug.Log("Player Enter Climbing");
            player = other.gameObject;

        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
         
            playerInZone = other.gameObject;

        }
    }

    public void Transport()
    {
        if (player == playerInZone)
        {
            player.transform.position = teleportTarget.transform.position;
            PlayerActions pa = player.GetComponent<PlayerActions>();
            pa.rb.velocity = Vector3.zero;
            pa.StartClimb();
        }
    }
}
