using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
public class Dialogue_Manager : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    //public string[] sentences;
    private Queue<string> Sentences;
    private int index;
    public float typingSpeed;

    private UnityAction someListner;

    private void Start()
    {
        Sentences = new Queue<string>();
    }
    private void Awake()
    {
        someListner = new UnityAction (StartTalking);
        
    }

    private void OnEnable()
    {
        EventManager.StartSubscribe("welcome", someListner);
       // EventManager.StartSubscribe("Next", NextScentence);
    }

    private void OnDisable()
    {
        EventManager.StopSubscribe("welcome", someListner);
        //EventManager.StopSubscribe("Next", NextScentence);

    }
    private void someOtherListner()
    {
       // StartCoroutine(Type());
    }

    private void StartTalking()
    {
       // StartCoroutine(Type());
    }

   // IEnumerator Type()
    //{
       // foreach (var letter in sentences[index].ToCharArray())
     //   {
      //      textDisplay.text += letter;
        //    yield return new WaitForSeconds(typingSpeed);
      //  }
  //  }

    // Update is called once per frame
    void Update()
    {

        if (GameObject.Find("TimeLine").GetComponentInChildren<ProgressBar_Script>().timeLeft < 110f && GameObject.Find("TimeLine").GetComponentInChildren<ProgressBar_Script>().timeLeft > 90f)
        {
           // EventManager.TriggerEvent("welcome");
            //GameObject.Find("Bubble").GetComponent<SpriteRenderer>().enabled = true;

           // if(index < sentences.Length -1)
            //{
             //   GameObject.Find("Bubble").GetComponent<SpriteRenderer>().enabled = false;
             //   EventManager.StopSubscribe("welcome", someListner);
             //   index++;
             //   textDisplay.text = ("");
           // }
        }

        else if (GameObject.Find("TimeLine").GetComponentInChildren<ProgressBar_Script>().timeLeft < 80f && GameObject.Find("TimeLine").GetComponentInChildren<ProgressBar_Script>().timeLeft > 60f)
        {
            EventManager.TriggerEvent("Next");
            GameObject.Find("Bubble").GetComponent<SpriteRenderer>().enabled = true;

           // if (index < sentences.Length - 1)
          //  {
             //   GameObject.Find("Bubble").GetComponent<SpriteRenderer>().enabled = false;
             //   EventManager.StopSubscribe("Next", someOtherListner);
            //    index++;
            //    textDisplay.text = ("");
          //  }
        }


    }

    //public void NextScentence()
   // {
      //  if (index < sentences.Length - 1)
      //  {
     //       index++;
     //       textDisplay.text = "";
     //       StartCoroutine(Type());
     //   }
     //   else
     //   {
     //       textDisplay.text = "";
     //   }

  //  }
}
