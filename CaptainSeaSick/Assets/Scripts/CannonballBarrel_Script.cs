using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonballBarrel_Script : MonoBehaviour
{
    public List<GameObject> cannonballList;

    public GameObject cannonballPrefab;
    // Start is called before the first frame update
    void Start()
    {
        cannonballList = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateCannonball(Vector3 position)
    {
        cannonballList.Add(Instantiate(cannonballPrefab, position, Quaternion.identity));
    }
}
