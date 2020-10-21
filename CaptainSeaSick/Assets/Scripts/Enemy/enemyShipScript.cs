using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyShipScript : MonoBehaviour
{
    public float HealthPoints = 10f;

    float timer = 10;
    private Vector3 direction;
    public GameObject enemyCannonball;
    public GameObject tempCannonBall;

    private Vector3 hitPosition;
    // Start is called before the first frame update
    /// <summary>
    /// Setting the hitposition depending on where the Enemyship is standing
    /// </summary>
    void Start()
    {

        if (transform.position.x < -50)
        {
            hitPosition = new Vector3(-8, -10, 10);
        }
        else if (transform.position.x > -30 && transform.position.x < -20)
        {
            hitPosition = new Vector3(-27, -10, 10);
        }
        else if(transform.position.x > -10 && transform.position.x < 2)
        {
            hitPosition = new Vector3(-3, -10, 10);
        }
        else
        {
            hitPosition = new Vector3(4, -10, 10);
        }

        transform.LookAt(hitPosition);
    }

    // Update is called once per frame
    /// <summary>
    /// Create and move an enemycannonball towards hitposition
    /// </summary>
    void Update()
    {
        
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            timer = 10;
            tempCannonBall = Instantiate(enemyCannonball, transform.position, Quaternion.identity);
        }

        if(tempCannonBall != null)
        {
            direction = Vector3.MoveTowards(tempCannonBall.transform.position, hitPosition, 0.4f);
            tempCannonBall.transform.position = direction;

            if (tempCannonBall.GetComponent<enemyCannonballScript>().isHit)
            {
                Destroy(tempCannonBall);
            }
        }

        if (HealthPoints <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
