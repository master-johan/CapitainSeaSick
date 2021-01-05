using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class enemyShipScript : MonoBehaviour
{
    string[] enemyNameArray;
    public float HealthPoints = 10f;
    public GameObject enemySpawnPosTop, enemySpawnPosLeft, enemySpawnPosRight;
    public GameObject enemyTop, enemyLeft, enemyRight;
    float shootTimer = 10;
    public float lifeTimer = 20;
    private Vector3 direction;
    public GameObject enemyCannonball;
    public GameObject tempCannonBall;
    public GameObject boardingEnemy;
    private Vector3 hitPosition;
    List<int> enemyPlaceList;

    List<GameObject> enemyList;

    bool instantiated;
    // Start is called before the first frame update
    /// <summary>
    /// Setting the hitposition depending on where the Enemyship is standing
    /// </summary>
    void Start()
    {
        enemyList = new List<GameObject>();

        enemyList.Add(enemyTop);
        enemyList.Add(enemyLeft);
        enemyList.Add(enemyRight);

        enemySpawnPosLeft = GameObject.Find("enemySpawnPosLeft");
        enemySpawnPosRight = GameObject.Find("enemySpawnPosRight");
        enemySpawnPosTop = GameObject.Find("enemySpawnPosTop");

        enemyNameArray = new string[3];

        enemyNameArray[0] = "Enemy_Top";
        enemyNameArray[1] = "Enemy_Right";
        enemyNameArray[2] = "Enemy_Left";

        enemyPlaceList = new List<int>();

        enemyPlaceList.Add(0);
        enemyPlaceList.Add(1);
        enemyPlaceList.Add(2);


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
    void FixedUpdate()
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

            for (int i = 0; i < 3; i++)
            {
                int rand = Random.Range(0, enemyPlaceList.Count);

                int temp = enemyPlaceList[rand];

                if (GameObject.Find(enemyNameArray[temp] + "(Clone)") == null)
                {
                    if (enemyNameArray[temp] == enemyLeft.name)
                    {
                        Instantiate(enemyLeft, enemySpawnPosLeft.transform.position, Quaternion.identity);
                        enemyPlaceList.RemoveAt(rand);
                        break;
                    }
                    else if (enemyNameArray[temp] == enemyRight.name)
                    {
                        Instantiate(enemyRight, enemySpawnPosRight.transform.position, Quaternion.identity);
                        enemyPlaceList.RemoveAt(rand);
                        break;
                    }
                    else if (enemyNameArray[temp] == enemyTop.name)
                    {
                        Instantiate(enemyTop, enemySpawnPosTop.transform.position, Quaternion.identity);
                        enemyPlaceList.RemoveAt(rand);
                        break;
                    }
                }
                enemyPlaceList.RemoveAt(rand);
            }

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

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PickableObject")
        {
            GetComponent<enemyShipScript>().HealthPoints -= GameAssets.instance.cannonballsDamage;
            Destroy(other.gameObject);
            Debug.Log("Health left: " + HealthPoints);
            if (GetComponent<enemyShipScript>().HealthPoints <= 0)
            {
                GameObject.Find("EnemyManager").GetComponent<EnemyManager>().AddBackDeadShipPosition(transform.position);
            }
        }
        //if (other.tag == "Player")
        //{

        //    other.GetComponent<PlayerActions>().SetFocus(gameObject, GetComponent<OffsetScript>().offsetX, GetComponent<OffsetScript>().offsetY);

        //}
    }

}
