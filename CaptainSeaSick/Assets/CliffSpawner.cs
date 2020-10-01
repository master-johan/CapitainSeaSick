using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CliffSpawner : MonoBehaviour
{

    public GameObject cliffPrefab;
    public float timer =20;

    void Start()
    {
        cliffPrefab.transform.position = new Vector3(-50, -12, Random.Range(-15, 15));
        Instantiate(cliffPrefab);
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            cliffPrefab.transform.position = new Vector3(-50, -10, Random.Range(-15, 15));
            Instantiate(cliffPrefab);
            timer = 20;
        }
    }
}
