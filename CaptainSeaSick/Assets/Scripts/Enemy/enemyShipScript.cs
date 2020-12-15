using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyShipScript : MonoBehaviour
{
    public float HealthPoints = 10f;

    float shootTimer = 10;
    public float lifeTimer = 20;
    private Vector3 direction;
    public GameObject enemyCannonball;
    public GameObject tempCannonBall;
    public GameObject boardingEnemy;

    private Vector3 hitPosition;
    // Start is called before the first frame update
    /// <summary>
    /// Setting the hitposition depending on where the Enemyship is standing
    /// </summary>
    void Start()
    {

        if (transform.position.x < -50)
        {
            hitPosition = new Vector3(-8, -8, 10);
        }
        else if (transform.position.x > -30 && transform.position.x < -15)
        {
            hitPosition = new Vector3(-23, -8, 10);
        }
        else if (transform.position.x > -10 && transform.position.x < 2)
        {
            hitPosition = new Vector3(-5, -8, 10);
        }
        else
        {
            hitPosition = new Vector3(12, -8, 11);
        }

        transform.LookAt(hitPosition);
    }

    // Update is called once per frame
    /// <summary>
    /// Create and move an enemycannonball towards hitposition
    /// </summary>
    void Update()
    {
        lifeTimer -= Time.deltaTime;
        shootTimer -= Time.deltaTime;

        if (shootTimer <= 0)
        {
            shootTimer = Random.Range(5, 15);
            tempCannonBall = Instantiate(enemyCannonball, transform.position, transform.rotation);
            SoundManager.Instance.PlaySoundEffect(GameAssets.instance.soundEffects[9], 0.5f);//Enemy cannon fire
        }

        if (lifeTimer <= 0)
        {

            Instantiate(boardingEnemy, hitPosition + new Vector3(0, 7, 0), Quaternion.identity);

            Destroy(tempCannonBall);
            Destroy(gameObject);
        }

        if (tempCannonBall != null)
        {
            direction = Vector3.MoveTowards(tempCannonBall.transform.position, hitPosition, 0.4f);
            tempCannonBall.transform.position = direction;

            //if (tempCannonBall.GetComponent<enemyCannonballScript>().isHit)
            //{
            //    Destroy(tempCannonBall);
            //}
        }

        if (HealthPoints <= 0)
        {
            Destroy(tempCannonBall);
            Destroy(this.gameObject);
        }
    }
}
