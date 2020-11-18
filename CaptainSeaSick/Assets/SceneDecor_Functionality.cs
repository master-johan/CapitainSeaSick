using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneDecor_Functionality : MonoBehaviour
{

    public List<GameObject> decor;
    public List<GameObject> spawnPositions;
    public float speed;
    public float timer;

    GameObject tempDecor;
    List<GameObject> tempDecorList;
    void Start()
    {
        tempDecorList = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {

            tempDecor = Instantiate(decor[Random.Range(0, decor.Count - 1)], spawnPositions[Random.Range(0, spawnPositions.Count)].transform.position, Quaternion.identity);         
            tempDecor.transform.Rotate(new Vector3(0, Random.Range(0, 360), 0));
            tempDecor.transform.localScale = tempDecor.transform.localScale * Random.Range(4, 5);

            tempDecorList.Add(tempDecor);

            timer = Random.Range(10, 40);
        }



        foreach (var item in tempDecorList)
        {
            item.transform.position -= new Vector3(speed, 0, 0) * Time.deltaTime;
        }
    }
}
