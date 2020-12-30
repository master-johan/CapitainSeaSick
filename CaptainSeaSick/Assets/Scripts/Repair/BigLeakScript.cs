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

    void FixedUpdate()
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
        GameObject.FindGameObjectWithTag("Ship").GetComponent<ShipHealth>().ModifyHealth(-GameAssets.instance.LeakDamage);
        damageTimer = 3;
        Debug.Log("Damage Done");
    }
    void RemoveLeak()
    {
        Destroy(gameObject);
    }
    /// <summary>
    /// If there is a plank on a leak then start to fix it.
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlankBandaid_Trigger>() && !other.gameObject.GetComponent<PlankBandaid_Trigger>().isPickedUp)
        {
            tempPlank = other.gameObject;
            plankOnLeak = true;
            tempPlank.GetComponent<PlankBandaid_Trigger>().DeactivateTriggerZone();
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
                tempSpawnPosition.GetComponent<Spawn_Script>().isUsed = false;
                Destroy(tempPlank);
                RemoveLeak();
            }
        }
    }

    public void SaveSpawnPosition(GameObject tempObject)
    {
        tempSpawnPosition = tempObject;
    }

    public void Repair()
    {
        if (plankOnLeak)
        {
            SoundManager.Instance.PlaySoundEffect(GameAssets.instance.soundEffects[6], 0.5f);
            GetComponentInChildren<RepairBarFunctionality>().SetSize(0.1f);
        }
    }
}
