using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWork : MonoBehaviour
{
    public GameObject fireWork;
    public float timer;
    float resetTime;
    void Start()
    {
        resetTime = timer;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            Vector3 randomPos = new Vector3(Random.Range(-100, 100), transform.position.y, transform.position.z);

            Instantiate(fireWork, randomPos, Quaternion.identity);

           timer = resetTime;
        }
    }
}
