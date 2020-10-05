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
    void Update()
    {
        if(isLoaded)
        {
            transform.position = cannon.transform.Find("CannonBallOffset").position;
            forwardPos = transform.position + cannon.transform.right * 1000000000f;
        }
        
        if(isShot)
        {
            transform.position = Vector3.MoveTowards(transform.position, forwardPos, 20 * Time.deltaTime);
            cannon = null;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            other.GetComponent<enemyShipScript>().HealthPoints -= damage;
            Destroy(this.gameObject);
            if (other.GetComponent<enemyShipScript>().HealthPoints <= 0)
            {
                GameObject.Find("EnemyManager").GetComponent<EnemyManager>().RemoveIndicators(other.transform.position);
            }
            Debug.Log("Enemy Struck");
        }
    }

    // Loading a cannonball into the cannon
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
}
