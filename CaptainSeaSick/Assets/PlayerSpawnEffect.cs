using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnEffect : MonoBehaviour
{
    private Color color;
    private ParticleSystem particleSystem;
    // Start is called before the first frame update
    void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();            
    }
    // Update is called once per frame
    void Update()
    {
        color = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManagement>().colorToSet;
        var main = particleSystem.main;
        main.startColor = color;
    }
}
