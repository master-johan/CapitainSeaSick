using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash : MonoBehaviour
{
    public Animator flash;
    public float transitionTime;
    // Start is called before the first frame update
    public void StartFlash()
    {
        flash.SetTrigger("Flash");
        
    }
    public void StopFlash()
    {
        flash.SetBool("Flash", false);
    }
}
