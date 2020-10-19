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

    private UnityAction startTalking, battleTalk, cliffTalk;

    void Start()
    {
        sentences = new Queue<string>();
        events = new Queue<string>();
        events.Enqueue("welcome");
        events.Enqueue("battle");
        
    }
    private void Awake()
    {
        startTalking = new UnityAction(FindObjectOfType<Dialogue_Trigger>().TriggerDialogue);
        battleTalk = new UnityAction(FindObjectOfType<Dialogue_Trigger>().TriggerDialogueBattle);
        cliffTalk = new UnityAction(FindObjectOfType<Dialogue_Trigger>().TriggerDialogueCliff);
    }

    private void OnEnable()
    {
        EventManager.StartSubscribe("welcome", startTalking);
        EventManager.StartSubscribe("battle", battleTalk);
        EventManager.StartSubscribe("cliff", cliffTalk);

    }

   

    private void OnDisable()
    {
        EventManager.StopSubscribe("welcome", startTalking);
        EventManager.StopSubscribe("battle", battleTalk);
        EventManager.StopSubscribe("cliff", cliffTalk);

    }


    public void StartDialogue(Dialogue dialogue)
    {


        foreach (var sent in dialogue.sentences)
        {
            sentences.Enqueue(sent);
        }

        NextSentence();


    }

    public void StartDialogueSingle(Dialogue dialogue)
    {
        int rndNr = UnityEngine.Random.Range(0, dialogue.sentences.Length);

        sentences.Enqueue(dialogue.sentences[rndNr]);

        NextSentence();


    }

    private void NextSentence()
    {

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
    }
    /// <summary>
    /// Coroutine to type out text character by character
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    IEnumerator typeText(string s)
    {
        foreach (var letter in s.ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        StartCoroutine(waitForSeconds(5f));        
    }
    /// <summary>
    /// Coroutine that makes the dialogue pause between dialogues
    /// </summary>
    /// <param name="time"></param>
    /// <returns></returns>
    IEnumerator waitForSeconds (float time)
    {
        float timeLeft = time;
        while (timeLeft > 0)
        {
            
            yield return new WaitForSeconds(1);
            timeLeft--;
        }
        textDisplay.text ="";
        NextSentence();
    }

    void Update()
    {
        if (events.Count >1 && GameObject.Find("TimeLine").GetComponentInChildren<ProgressBar_Script>().progress == 98)
        {
            string eventToTrigger = events.Dequeue();
            EventManager.TriggerEvent(eventToTrigger);
        }

        //if (events.Count > 0 && GameObject.Find("TimeLine").GetComponentInChildren<ProgressBar_Script>().progress ==80)
        //{
        //    string eventToTrigger = events.Dequeue();
        //    EventManager.TriggerEvent(eventToTrigger);
        //}
    }
    /// <summary>
    /// Method to end dialogue and turn of the renderer for the speechbubble
    /// </summary>
    private void EndDialogue()
    {
        endDialogue = true;
        GameObject.Find("Bubble").GetComponent<SpriteRenderer>().enabled = false;
        EventManager.StopSubscribe("welcome", startTalking);
    }



 


}
