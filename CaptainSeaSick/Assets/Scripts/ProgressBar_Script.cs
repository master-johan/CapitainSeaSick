using System.Collections;
using System.Collections.Generic;
using System.Security.Permissions;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class ProgressBar_Script : MonoBehaviour
{
    private Slider slider;
    public float levelTime = 120f; //2 MIN
    public float timeLeft; //How long left

    private void Awake()
    {
        slider = gameObject.GetComponent<Slider>();
    }
    void Start()
    {
        
        timeLeft = levelTime;
        slider.value = timeLeft;
    }

    // Update is called once per frame
    void Update()
    {
       

        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            slider.value = timeLeft / levelTime;
        }
        else
        {
            Time.timeScale = 0;
        }      
    }

    public void IncrementProgress(float newProgress)
    {
        slider.value += newProgress;
    }
}
