using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue_Trigger : MonoBehaviour
{
    public Dialogue dialogue;
    public Dialogue battleDialogue;

    public void TriggerDialogue()
    {
        FindObjectOfType <Dialogue_Manager>().StartDialogue(dialogue);
        //Debug.Log("trigger dialog");
    }

    public void TriggerDialogueBattle()
    {
        FindObjectOfType<Dialogue_Manager>().StartDialogue(battleDialogue);
        //Debug.Log("trigger dialog");
    }
}
