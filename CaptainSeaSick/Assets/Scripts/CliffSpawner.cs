using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CliffSpawner : MonoBehaviour
{

    public GameObject cliffPrefab;
    public float timer =20;

    private UnityAction cliffListener;
    string cliffSpawnString = "SpawnCliff";

    private void Awake()
    {
        cliffListener = new UnityAction(SpawnCliff);
    }

    private void OnEnable()
    {
        EventManager.StartSubscribe(cliffSpawnString, cliffListener);
    }

    private void OnDisable()
    {
        EventManager.StopSubscribe(cliffSpawnString, cliffListener);
    }

    void Start()
    {
        //cliffPrefab.transform.position = new Vector3(-50, -12, Random.Range(-15, 15));
        //Instantiate(cliffPrefab);
    }

    // Update is called once per frame
    void Update()
    {
        //timer -= Time.deltaTime;

        //if (timer <= 0)
        //{
        //    SpawnCliff();
        //    timer = 20;
        //}
    }

    private void SpawnCliff()
    {
        cliffPrefab.transform.position = new Vector3(-50, -10, Random.Range(-15, 15));
        Instantiate(cliffPrefab);
    }
}
