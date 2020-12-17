using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnEffect : MonoBehaviour
{
    private Color color;
    public ParticleSystem particleSystem;
    // Start is called before the first frame update
    void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();            
    }
    // Update is called once per frame
    void Update()
    {

        
    }

    public void SetParticleColor(Color color)
    {
        ParticleSystem.MainModule settings = particleSystem.GetComponent<ParticleSystem>().main;
        settings.startColor = new ParticleSystem.MinMaxGradient(color);
    }
}
