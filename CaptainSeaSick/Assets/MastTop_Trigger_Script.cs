using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MastTop_Trigger_Script : MonoBehaviour
{
    public GameObject telportTarget;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Transport(other.gameObject);
        }
    }

    private void Transport(GameObject player)
    {
        player.transform.position = telportTarget.transform.position;
        PlayerActions pa = player.GetComponent<PlayerActions>();
        pa.rb.velocity = Vector3.zero;
        pa.StopClimb();
    }
}
