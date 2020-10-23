using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    public bool isPickedUp;
    public bool isLoaded;
    public bool isShot;

    public float damage = 5f;
  
   
    private GameObject cannon;
    private Vector3 forwardPos;
    // Start is called before the first frame update
    void Start()
    {
        isPickedUp = false;
     
    }

    // Update is called once per frame
    /// <summary>
    /// setting the cannonballs position when loaded and shot.
    /// </summary>
    void Update()
    {
        if(isLoaded)
        {
            transform.position = cannon.transform.Find("CannonBallOffset").position;
            forwardPos = transform.position + cannon.transform.right * 1000f;
        }
        
        if(isShot)
        {
            transform.position = Vector3.MoveTowards(transform.position, forwardPos, 20 * Time.deltaTime);
            cannon = null;
        }
    }
    /// <summary>
    /// When it collides with an enemy it does damage and remove the indicator for that ship if it gets destroyed.
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            other.GetComponent<enemyShipScript>().HealthPoints -= damage;
            Destroy(this.gameObject);
            if (other.GetComponent<enemyShipScript>().HealthPoints <= 0)
            {
                GameObject.Find("EnemyManager").GetComponent<EnemyManager>().AddBackDeadShipPosition(other.transform.position);
            }
        }
        //if (other.tag == "Player")
        //{
            
        //    other.GetComponent<PlayerActions>().SetFocus(gameObject, GetComponent<OffsetScript>().offsetX, GetComponent<OffsetScript>().offsetY);
                  
        //}
    }

    /// <summary>
    /// If a cannonball is staying inside a cannons boxcollider and isn't in a players hand.
    /// If the cannon isn't loaded with another cannonball.
    /// Then the cannonball gets one cannon attached to it, the cannonball becomes a trigger since it needs to check if it hits an enemyship,
    /// it becomes kinematic since it doesn't need any velocity, the cannonball "isLoaded", the cannon is loaded, the cannon gets this cannonball and it wont render for now.
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerStay(Collider other)
    {
        if (other.GetComponent("Cannon_Script") && !isPickedUp)
        {
            if(other.GetComponent<Cannon_Script>().cannonBall == null)
            {
                cannon = other.gameObject;
                transform.GetComponent<SphereCollider>().isTrigger = true;
                transform.GetComponent<Rigidbody>().isKinematic = true;
                isLoaded = true;
                other.GetComponent<Cannon_Script>().cannonState = Cannon_Script.CannonState.loaded;
                cannon.GetComponent<Cannon_Script>().SetCannonBall(this.gameObject);
                GetComponent<MeshRenderer>().enabled = false;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //if (other.tag == "Player")
        //{
        //    PlayerActions pa = other.GetComponent<PlayerActions>();
        //    if (pa.focusedObject = gameObject)
        //    {
        //        pa.SetFocus(null, 0, 0);
        //    }
        //}
    }

  
}
