using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaneCollider : MonoBehaviour
{
    float startingTime;
    public GameObject repairprefab;
    public Vector3 center;
    public Vector3 size;
    bool isSpawned = false;
    bool isDestroyed = false;
    int hit = 0;


    public float nextRepair = 50f;


    int i = 1;


    public Text countdownText;
    

    private void Start()
    {


    }
    private void Update()
    {

        startingTime += Time.deltaTime;

        if (startingTime > nextRepair && i == 1)
        {
            SpawnRepair();
            i++;
        }

        string minutes = ((int)startingTime / 60).ToString();
        string seconds = (startingTime % 60).ToString("f1");

        countdownText.text = minutes + ":" + seconds;




    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Plank" | collision.gameObject.name == "Plank(Clone)")
        {
            hit++;
            if (hit == 5)
            {
                hitcheck();
            }
            
        }
    }
    private void hitcheck()
    {
        isDestroyed = true;
        Destroy(gameObject);
    }
    private void OnCollisionExit(Collision collision)
    {
        
    }
    public void SpawnRepair()
    {
        isSpawned = true;

        Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));

        Instantiate(repairprefab, pos, Quaternion.identity);
        
        return;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(center, size);
    }
}
