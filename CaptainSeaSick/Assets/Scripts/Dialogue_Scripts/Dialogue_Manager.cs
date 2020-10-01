using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using System.Text;
using UnityEngine.PlayerLoop;

public class Dialogue_Manager : MonoBehaviour
{
    [SerializeField]
    public TextMeshProUGUI textDisplay;  
    [SerializeField]
    public float typingSpeed;
    private int index;
    public Queue<string> sentences;
    public string currentSentence;
    bool endDialogue = false;

    public Queue<string> events;

    private UnityAction startTalking;

    void Start()
    {
        sentences = new Queue<string>();
        events = new Queue<string>();
        events.Enqueue("welcome");
    }
    private void Awake()
    {
        startTalking = new UnityAction(FindObjectOfType<Dialogue_Trigger>().TriggerDialogue);
    }

    private void OnEnable()
    {
        EventManager.StartSubscribe("welcome", startTalking);

    }

    private void OnDisable()
    {
        EventManager.StopSubscribe("welcome", startTalking);

    }

    public void StartDialogue(Dialogue dialogue)
    {


        foreach (var sent in dialogue.sentences)
        {
            sentences.Enqueue(sent);
        }

       StartCoroutine(Type());


    }

    private void NextSentence()
    {

        Debug.Log(sentences.Count + "sentences left");
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
       
        currentSentence = sentences.Dequeue();
        
        PrintText(currentSentence);

    }

    private void PrintText(string currentSentence)
    {
        GameObject.Find("Bubble").GetComponent<SpriteRenderer>().enabled = true;
        StartCoroutine(typeText(currentSentence));
        Debug.Log(currentSentence);   
    }

    IEnumerator typeText(string s)
    {
        foreach (var letter in s.ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        StartCoroutine(waitForSeconds(5f));        
    }

    IEnumerator waitForSeconds (float time)
    {
        float timeLeft = time;
        while (timeLeft > 0)
        {
            Debug.Log(timeLeft);
            yield return new WaitForSeconds(1);
            timeLeft--;
        }
        textDisplay.text ="";
        NextSentence();
    }

    void Update()
    {
        if (events.Count >0 && GameObject.Find("TimeLine").GetComponentInChildren<ProgressBar_Script>().progress == 98)
        {
            string eventToTrigger = events.Dequeue();
            EventManager.TriggerEvent(eventToTrigger);
        }                                    
    }

    private void EndDialogue()
    {
        endDialogue = true;
        Debug.Log("EndDialogue");
        GameObject.Find("Bubble").GetComponent<SpriteRenderer>().enabled = false;
        EventManager.StopSubscribe("welcome", startTalking);
    }



 


}
