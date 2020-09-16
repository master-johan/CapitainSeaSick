using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    public bool isPickedUp;
    // Start is called before the first frame update
    void Start()
    {
        isPickedUp = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider collider)
    {
    }

    void OnTriggerStay(Collider collider)
    {
        if (collider.GetComponent("Cannon_Script") && !isPickedUp)
        {
            Debug.Log("Hej");
            Destroy(this.gameObject);
            collider.GetComponent<Cannon_Script>().cannonState = Cannon_Script.CannonState.loaded;
        }
    }
}
