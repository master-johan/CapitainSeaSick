using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrail_Script : MonoBehaviour
{

    ParticleSystem ps;
    // Start is called before the first frame update
    void Start()
    {
        ps.GetComponent<ParticleSystem>();
        ParticleSystem.MainModule ma = ps.main;

       // ma.startColor = new Color...
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
