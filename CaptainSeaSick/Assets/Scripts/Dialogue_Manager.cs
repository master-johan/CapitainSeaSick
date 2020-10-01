using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using System.Text;

public class Dialogue_Manager : MonoBehaviour
{
    [SerializeField]
    public TextMeshProUGUI textDisplay;  
    [SerializeField]
    public float typingSpeed;
    private int index;
    public Queue<string> sentences;
    public string currentSentence;
    bool once = false;
    //Dialogue dialogue1 = new Dialogue(); 

    private UnityAction startTalking;

    void Start()
    {
        sentences = new Queue<string>();
    }

    /// <summary>
    /// Method is starting a dialog from queue
    /// </summary>
    /// <param name="dialogue"></param>
    public void StartDialogue(Dialogue dialogue)
    {
        
        //Debug.Log("Starting to talk" + dialogue.name);

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
            index++;
            //Debug.Log(sentence);
        }
        StartCoroutine(StartAfterTime(10));
    }
    public void NextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            
            return;
        }
        else
        {
            currentSentence = sentences.Dequeue();
            Debug.Log(currentSentence);
            textDisplay.text = currentSentence;
            //StartCoroutine(Type());
        }
    }

    private void EndDialogue()
    {
        
        Debug.Log("End of Speech");
    }
    /// <summary>
    /// Method is deciding typing speed
    /// </summary>
    /// <returns></returns>
    IEnumerator Type()
    {
        Debug.Log("inside type");
        foreach (var letter in currentSentence.ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
            
        }
    }
    /// <summary>
    /// Method is delaying time between sentences
    /// </summary>
    /// <param name="time"></param>
    /// <returns></returns>
    IEnumerator StartAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        Debug.Log("inside wait second");
        NextSentence();
    }

    // Update is called once per frame
    void Update()
    {
       
        if (GameObject.Find("TimeLine").GetComponentInChildren<ProgressBar_Script>().progress == 98 && !once)
        {
            GameObject.Find("Bubble").GetComponent<SpriteRenderer>().enabled = true;
            EventManager.TriggerEvent("welcome");
            once = true;

        }
        else if (once)
        {

            EventManager.StopSubscribe("welcome", startTalking);
            textDisplay.text = ("");

        }
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

 


}
