using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CliffSpawner : MonoBehaviour
{

    public GameObject cliffPrefab;
    private GameObject tempCliff;
    public float timer = 20;
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
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void SpawnCliff()
    {
        cliffPrefab.transform.position = new Vector3(-100, -10, Random.Range(-15, 15));
        tempCliff = Instantiate(cliffPrefab);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Cliff")
        {
            //Move the indicator if the cliff is destoryed out of bounds
            other.gameObject.GetComponent<BoatMovement>().indicatorPosition = new Vector3(200, 200, 200);
            Destroy(other.gameObject);
        }
    }
}
