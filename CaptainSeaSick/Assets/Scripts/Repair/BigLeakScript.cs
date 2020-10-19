using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigLeakScript : MonoBehaviour
{
    // Start is called before the first frame update
    float damageTimer = 3;
    public bool plankOnLeak, playerOnRepairSpot;
    GameObject tempSpawnPosition, tempPlank;
    void Start()
    {
    }

    void Update()
    {
        damageTimer -= Time.deltaTime;
        if (damageTimer <= 0)
        {
            DoDamage();
        }

        if (plankOnLeak)
        {
            tempPlank.transform.position = transform.position;
            tempPlank.transform.rotation = new Quaternion((transform.rotation.x - 90), transform.rotation.y, transform.rotation.z - 45, 0);

            tempPlank.GetComponent<Rigidbody>().isKinematic = true;
            tempPlank.GetComponent<Rigidbody>().freezeRotation = true;
            tempPlank.GetComponent<Collider>().enabled = false;

            LeakFixed(tempPlank);

            transform.Find("SmallLeak").gameObject.SetActive(true);
            transform.Find("BigLeak").gameObject.SetActive(false);

        }

    }

    void DoDamage()
    {
        GameObject.FindGameObjectWithTag("Ship").GetComponent<ShipHealth>().ModifyHealth(-5);
        damageTimer = 3;
    }
    void RemoveLeak()
    {
        Destroy(gameObject);
    }
    /// <summary>
    /// If there is a plank on a leak then start to fix it.
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<Plank_Script>() && !other.gameObject.GetComponent<Plank_Script>().isPickedUp)
        {
            tempPlank = other.gameObject;
            plankOnLeak = true;

        }
        if (other.tag == "Player")
        {
            playerOnRepairSpot = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerOnRepairSpot = false;
        }

    }
    /// <summary>
    /// If timer is <= 0 then remove leak and the plank.
    /// </summary>
    /// <param name="tempPlank"></param>
    void LeakFixed(GameObject tempPlank)
    {
        if (gameObject.GetComponentInChildren<RepairBarFunctionality>().bar != null)
        {
            if (gameObject.GetComponentInChildren<RepairBarFunctionality>().bar.localScale.x >= 1)
            {
                RemoveLeak();
                tempSpawnPosition.GetComponent<Spawn_Script>().isUsed = false;
                Destroy(tempPlank);
            }
        }
    }

    public void SaveSpawnPosition(GameObject tempObject)
    {
        tempSpawnPosition = tempObject;
    }
}
