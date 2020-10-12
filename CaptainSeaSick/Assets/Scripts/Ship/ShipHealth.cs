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

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Cliff")
        {
            Destroy(other.gameObject);
            ModifyHealth(-10);
        }
    }

}
