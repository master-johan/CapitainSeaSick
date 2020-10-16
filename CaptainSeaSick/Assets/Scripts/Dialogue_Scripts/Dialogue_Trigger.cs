using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue_Trigger : MonoBehaviour
{
    public Dialogue dialogue;
    public Dialogue battleDialogue;
    public Dialogue cliffDialogue;

    public void TriggerDialogue()
    {
        FindObjectOfType <Dialogue_Manager>().StartDialogue(dialogue);
    }

    public void TriggerDialogueBattle()
    {
        FindObjectOfType<Dialogue_Manager>().StartDialogueSingle(battleDialogue);
    }

    public void TriggerDialogueCliff()
    {
        FindObjectOfType<Dialogue_Manager>().StartDialogueSingle(cliffDialogue);
    }
}
