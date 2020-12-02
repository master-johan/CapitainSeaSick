using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue_Trigger : MonoBehaviour
{
    Dialogue_Manager dialogue_Manager;
    Dialogue dialogue;
    Dialogue shipSpawnDialogue;
    Dialogue cliffDialogue;

    private void Start()
    {
        dialogue_Manager = FindObjectOfType<Dialogue_Manager>();
        dialogue = GameAssets.instance.startLevelDialogue;
        shipSpawnDialogue = GameAssets.instance.shipSpawnDialogue;
        cliffDialogue = GameAssets.instance.cliffSpawnDialogue;

    }


    public void TriggerDialogue()
    {
        dialogue_Manager.StartDialogue(dialogue);
    }

    public void TriggerDialogueBattle()
    {
        dialogue_Manager.StartDialogueSingle(shipSpawnDialogue);
    }

    public void TriggerDialogueCliff()
    {
        dialogue_Manager.StartDialogueSingle(cliffDialogue);

    }
}

