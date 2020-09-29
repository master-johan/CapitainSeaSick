using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCannonBallScript : MonoBehaviour
{
    public bool cannonBallHit;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Ship")
        {
            Debug.Log("Ship has been hit");
            cannonBallHit = true;
        }
    }
}
