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
    private GameObject spawnPositions;

    private Vector3 hitPosition;
    // Start is called before the first frame update
    /// <summary>
    /// Setting the hitposition depending on where the Enemyship is standing
    /// </summary>
    void Start()
    {

        spawnPositions = GameObject.FindGameObjectWithTag("SpawnPositions");
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

            if (tempCannonBall.GetComponent<enemyCannonballScript>().isHit || tempCannonBall.GetComponent<enemyCannonballScript>().aliveTimer >= 1f)
            {
                Destroy(tempCannonBall);
                spawnPositions.GetComponent<SpawnPositionsScript>().SpawnLeak();
            }
        }

        if (HealthPoints <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
