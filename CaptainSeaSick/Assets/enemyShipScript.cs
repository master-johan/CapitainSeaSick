using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyShipScript : MonoBehaviour
{
    public float HealthPoints = 10f;

    float timer = 3;
    private Vector3 direction;
    public GameObject enemyCannonball;
    public GameObject tempCannonBall;

    private Vector3 hitPosition;
    // Start is called before the first frame update
    void Start()
    {
        if (transform.position == new Vector3(-2, -4, -85) || transform.position == new Vector3(-2, -4, 85))
        {
            hitPosition = new Vector3(-2, -5, -0.5f);
        }
        else
        {
            hitPosition = new Vector3(-13, -5, -0.5f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            timer = 3;
            tempCannonBall = Instantiate(enemyCannonball, transform.position, Quaternion.identity);
        }

        if(tempCannonBall != null)
        {
            direction = Vector3.MoveTowards(tempCannonBall.transform.position, hitPosition, 0.4f);
            tempCannonBall.transform.position = direction;

            if (tempCannonBall.GetComponent<enemyCannonballScript>().isHit || tempCannonBall.GetComponent<enemyCannonballScript>().aliveTimer >= 2.5f)
            {
                Destroy(tempCannonBall);
                GameObject.FindGameObjectWithTag("Ship").GetComponent<ShipHealth>().ModifyHealth(-5);
            }
        }

        if (HealthPoints <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
