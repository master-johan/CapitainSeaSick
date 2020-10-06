using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrellSpawner : MonoBehaviour
{
    public GameObject barrell;
    private GameObject tempBarrell;
    public float timer = 10;

    void Start()
    {
        tempBarrell = barrell;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            tempBarrell = Instantiate(barrell);
            tempBarrell.transform.position = transform.position;

            timer = 10;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "RollingBarrell")
        {
            Destroy(tempBarrell);
        }
    }
}
