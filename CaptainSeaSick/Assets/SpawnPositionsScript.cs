using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPositionsScript : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject[] spawnPositionArray = new GameObject[6];
    public GameObject Leak;
    GameObject tempGameObject;
    void Start()
    {

    }

    public void SpawnLeak()
    {
        tempGameObject = spawnPositionArray[Random.Range(0, 6)];
        Vector3 center = tempGameObject.transform.position;
        Vector3 objectSize = tempGameObject.GetComponent<MeshCollider>().bounds.size; // the size of the plane
        Vector3 spawnPositionX = new Vector3(Random.Range(-objectSize.x / 2, objectSize.x / 2), 0, 0);
        Vector3 spawnPositionZ = new Vector3(0, 0, Random.Range(-objectSize.z / 2, objectSize.z / 2));
        Vector3 spawnPosition = center + spawnPositionX + spawnPositionZ;
        Instantiate(Leak, spawnPosition, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
