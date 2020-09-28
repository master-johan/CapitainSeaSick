using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
public class Dialogue_Script : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    public float typingSpeed;

    private UnityAction someListner;

    private void Awake()
    {
        someListner = new UnityAction (StartTalking);
    }

    private void OnEnable()
    {
        EventManager.StartSubscribe("welcome", someListner);
    }

    private void OnDisable()
    {
        EventManager.StopSubscribe("welcome", someListner);

    }

    private void StartTalking()
    {
        StartCoroutine(Type());
    }

    IEnumerator Type()
    {
        foreach (var letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (GameObject.Find("TimeLine").GetComponentInChildren<ProgressBar_Script>().timeLeft < 110f && GameObject.Find("TimeLine").GetComponentInChildren<ProgressBar_Script>().timeLeft > 90f)
        {
            EventManager.TriggerEvent("welcome");
            GameObject.Find("Bubble").GetComponent<SpriteRenderer>().enabled = true;

            if(index < sentences.Length -1)
            {
                EventManager.StopSubscribe("welcome", someListner);
                index++;
                textDisplay.text = ("");
            }
        }
    }

    public void NextScentence()
    {
        if(index < sentences.Length -1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else
        {
            textDisplay.text = "";
        }
      
    }
}
