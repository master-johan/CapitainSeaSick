using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropZoneFunctionality : MonoBehaviour
{
    public GameObject droppedItem;
    public bool itemDropped;
    private GameObject scavManager;
   
    void Start()
    {
        scavManager = GameObject.Find("ScavengingManager");
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Player is in DropZone");
        }
        if(other.tag == "PickableObject")
        {
            Debug.Log("Colliding "+ other.name);
            if (other.GetComponentInChildren<PickUp_Trigger_Script>().pickUpStatus == PickUp.free)
            {
                //Saves the value of the PickableObject which collides with the dropzone hitbox.
                droppedItem = other.gameObject;
                itemDropped = true;
                Debug.Log("Dropped Item");
            }
         
        }
    }
    public void DropZoneUpdate()
    {
        if (droppedItem != null)
        {
            Debug.Log("Update works");
            //Adds a point to the different resource values depending on which item is dropped in the dropzone.
            if (itemDropped)
            {
                Debug.Log("2 stage");
                if (droppedItem.GetComponent<Chest_Trigger_Script>())
                {
                    GameAssets.instance.gold += 15;
                }
                if (droppedItem.GetComponent<Bag_Trigger_Script>())
                {
                    GameAssets.instance.gold += 5;
                }
                if (droppedItem.GetComponent<CannonBall>())
                {
                    
                }
                SoundManager.Instance.PlaySoundEffect(GameAssets.instance.soundEffects[2], 0.7f);

                //Destroy the item that lands in the dropzone and reset the bool.
                for (int i = 0; i < scavManager.GetComponent<ScavengingManager>().goldList.Count; i++)
                {
                    if(droppedItem == scavManager.GetComponent<ScavengingManager>().goldList[i])
                    {
                        scavManager.GetComponent<ScavengingManager>().goldList.RemoveAt(i);
                    }
                }
                Destroy(droppedItem);
                itemDropped = false;
            }
        }
    }
}
