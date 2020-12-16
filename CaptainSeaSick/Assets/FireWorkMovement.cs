using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWorkMovement : MonoBehaviour
{
    float timer, lifeTimer;
    public GameObject boom;


    // Start is called before the first frame update
    void Start()
    {
        ParticleSystem.MainModule settings = boom.GetComponent<ParticleSystem>().main;
        settings.startColor = new ParticleSystem.MinMaxGradient(new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f)));



        timer = Random.Range(1f, 3f);

        lifeTimer = timer + 4;
        for (int i = 0; i < boom.GetComponent<ParticleSystem>().emission.burstCount; i++)
        {
            boom.GetComponent<ParticleSystem>().emission.SetBurst(i, new ParticleSystem.Burst(timer, 500));
         
        }
    }

    // Update is called once per frame
    void Update()
    {

        timer -= Time.deltaTime;
        lifeTimer -= Time.deltaTime;
        if (timer > 0)
        {
            transform.position += new Vector3(0, 50, 0) * Time.deltaTime;
        }

        if(lifeTimer <= 0)
        {
            Destroy(this.gameObject);
        }


    }
}
