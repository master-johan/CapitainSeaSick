using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeakScript : MonoBehaviour
{
    // Start is called before the first frame update
    float damageTimer = 3;
    float fixLeakTimer = 5;
    bool startedFixingLeak;
    GameObject tempSpawnPosition;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        damageTimer -= Time.deltaTime;
        if (damageTimer <= 0)
        {
            DoDamage();
        }
        if (startedFixingLeak)
        {
            fixLeakTimer -= Time.deltaTime;
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
            startedFixingLeak = true;
            UpdateLeakTimer(other.gameObject);
        }
        else if (other.gameObject.GetComponent<Plank_Script>() && other.gameObject.GetComponent<Plank_Script>().isPickedUp)
        {
            ResetLeakTimer();
        }
    }

    private void ResetLeakTimer()
    {
        fixLeakTimer = 5;
        startedFixingLeak = false;
    }
    /// <summary>
    /// If timer is <= 0 then remove leak and the plank.
    /// </summary>
    /// <param name="tempPlank"></param>
    void UpdateLeakTimer(GameObject tempPlank)
    {
        if (fixLeakTimer <= 0)
        {
            RemoveLeak();
            tempSpawnPosition.GetComponent<Spawn_Script>().isUsed = false;
            Destroy(tempPlank);
        }
    }

    public void SaveSpawnPosition(GameObject tempObject)
    {
        tempSpawnPosition = tempObject;
    }
}
