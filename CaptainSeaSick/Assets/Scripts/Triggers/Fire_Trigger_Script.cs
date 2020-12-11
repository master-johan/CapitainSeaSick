using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire_Trigger_Script : MonoBehaviour
{
    private GameObject scavManager;
    public GameObject waterEffect;
    // Start is called before the first frame update
    float timer;
    private void Start()
    {
        scavManager = GameObject.Find("ScavengingManager");
        timer = 0.3f;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Bucket")
        {
            waterEffect.GetComponent<ParticleSystem>().Play();

        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.name == "Bucket")
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                GameObject.Find("Water").SetActive(false);
                gameObject.SetActive(false);
            }

        }
        else if (other.tag == "Player")
        {
            if (!other.isTrigger)
            {
                other.GetComponent<PlayerManagement>().PlayerScavRespawn();
            }
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
