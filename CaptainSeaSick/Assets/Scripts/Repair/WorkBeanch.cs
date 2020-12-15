using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkBeanch : MonoBehaviour
{

    GameObject[] plankSpots;
    GameObject tempPlank;
    List<GameObject> plankList;
    int counter;
    bool canBeCrafted;

    void Start()
    {
        plankList = new List<GameObject>();
        plankSpots = new GameObject[4];
        plankSpots[0] = GameObject.Find("Spot1");
        plankSpots[1] = GameObject.Find("Spot2");
        plankSpots[2] = GameObject.Find("Spot3");
        plankSpots[3] = GameObject.Find("Spot4");
    }


    void FixedUpdate()
    {
        if (canBeCrafted)
        {

        }

        

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Plank_Script>() && !other.gameObject.GetComponent<Plank_Script>().isPickedUp)
        {
            tempPlank = other.gameObject;
            tempPlank.GetComponent<Rigidbody>().isKinematic = true;
            tempPlank.GetComponent<Rigidbody>().freezeRotation = true;
            tempPlank.GetComponent<Collider>().enabled = false;

            
            if(plankList.Count == 4)
            {
                canBeCrafted = true;
            }
            else if(counter < 4)
            {
                plankList.Add(tempPlank);
               
                tempPlank.transform.position = plankSpots[counter].transform.position;
                tempPlank.transform.forward = plankSpots[counter].transform.forward;
                counter++;

                foreach (var item in plankList)
                {
                    Debug.Log(item.name);
                }
            }

            //  tempPlank.GetComponent<Plank_Script>().DeactivateTriggerZone();
        }
    }

}
