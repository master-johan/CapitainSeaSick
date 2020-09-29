using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipHealth : MonoBehaviour
{
    [SerializeField]
    private float maxHealth = 100;
    public float currenthealth;

    public event Action <float> healthPctChanged = delegate { };
    private void OnEnable()
    {
        currenthealth = maxHealth;
    }

    public void ModifyHealth(float amount)
    {
        currenthealth += amount;
        float currentHeathPct = currenthealth / maxHealth;
        healthPctChanged(currentHeathPct);
    }
    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Cliff")
        {
            ModifyHealth(-10);
            Destroy(other.gameObject);
        }
        if(other.tag == "EnemyCannonBall")
        {
            ModifyHealth(-10);
        }
    }

}
