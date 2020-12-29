using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipHealth : MonoBehaviour
{
    public GameObject loseScreen;
    private float maxHealth;
    public float currenthealth;
    private GameObject spawnPositions;
    [SerializeField] Flash flashImage;
    public GameObject ExplosionEffect;


    public event Action <float> healthPctChanged = delegate { };
    private void OnEnable()
    {
        maxHealth = GameAssets.instance.ShipMaxHealth;
        currenthealth = maxHealth;
        spawnPositions = GameObject.FindGameObjectWithTag("SpawnPositions");

    }

    /// <summary>
    /// Method to be called to modify the health value of the ship 
    /// (This method does not modify the fill in the healthbar that happends in the healthbar script)
    /// </summary>
    /// <param name="amount"></param>
    public void ModifyHealth(float amount)
    {
        currenthealth += amount;
        float currentHeathPct = currenthealth / maxHealth;
        healthPctChanged(currentHeathPct);
    }
    void Update()
    {
        if(currenthealth <= 0)
        {
            Time.timeScale = 0;
            Instantiate(loseScreen);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
       
       
        if (other.collider.tag == "EnemyCannonball")
        {
            //tempDirection = (transform.position - tempTransform.position);
            //tempContactPoint = tempTransform.position + tempDirection;
            ContactPoint con = other.contacts[0];
            Quaternion rot = Quaternion.FromToRotation(-Vector3.forward, con.normal);
            Vector3 pos = con.point;
            Instantiate(ExplosionEffect,pos, rot);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Cliff")
        {
            SoundManager.Instance.PlaySoundEffect(GameAssets.instance.soundEffects[5], 1f);
            Destroy(other.gameObject);
            spawnPositions.GetComponent<SpawnPositionsScript>().SpawnLeak();
            Debug.Log(spawnPositions.GetComponent<SpawnPositionsScript>().allSpawnPositionUsed);
        }
        if(other.tag == "EnemyCannonball")
        {
            //tempDirection = (transform.position - tempTransform.position);
            //tempContactPoint = tempTransform.position + tempDirection;
           // Instantiate(ExplosionEffect, other.transform.position, new Quaternion(-other.transform.forward.x, -other.transform.forward.y, -other.transform.forward.z, 0));
            Destroy(other.gameObject);
            SoundManager.Instance.PlaySoundEffect(GameAssets.instance.soundEffects[8], 0.05f);
            ModifyHealth(-1);
            flashImage.StartFlash();
        }
    }
}
