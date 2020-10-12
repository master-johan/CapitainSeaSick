using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropZoneFunctionality : MonoBehaviour
{
    public GameObject droppedItem;
    public bool itemDropped;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "PickableObject")
        {
            //Saves the value of the PickableObject which collides with the dropzone hitbox.
            droppedItem = other.gameObject;
            itemDropped = true;
        }
    }
}
