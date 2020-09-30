using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaneCollider : MonoBehaviour
{
    float startingTime;

    public Text countdownText;
    public bool timerOn;

    private void Start()
    {
        startingTime = Time.time;
        
    }
    //private void Update()
    //{
    //    float t = Time.time - startingTime;

    //    string minutes = ((int)t / 60).ToString();
    //    string seconds = (t % 60).ToString("f2");

    //    countdownText.text = minutes + ":" + seconds;
    //}

    void OnTriggerEnter(Collider other)
    {
        //startingTime = Time.time;

        float t = Time.time - startingTime;

            string minutes = ((int)t / 60).ToString();
            string seconds = (t % 60).ToString("f2");

            countdownText.text = minutes + ":" + seconds;
        

    }
}
