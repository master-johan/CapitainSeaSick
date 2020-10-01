using System.Collections;
using System.Collections.Generic;
using System.Xml;
using TMPro;
using UnityEngine;

public class MapController : MonoBehaviour
{
    GameObject movingWall;
    GameObject dropZone;

    private bool dirRight = true;
    float wallSpeed = 2.0f;


    private void Start()
    {
        movingWall = GameObject.Find("MovingWall");
        dropZone = GameObject.Find("DropZone");
    }
    void Update()
    {
        if (dirRight)
            movingWall.transform.Translate(Vector2.right * wallSpeed * Time.deltaTime);
        else
            movingWall.transform.Translate(-Vector2.right * wallSpeed * Time.deltaTime);

        if (movingWall.transform.localPosition.x >= 60.0f)
        {
            dirRight = false;
        }

        if (movingWall.transform.localPosition.x <= 38)
        {
            dirRight = true;
        }


        if(dropZone.GetComponent<DropZoneFunctionality>().itemDropped)
        {
            Debug.Log("Item has been dropped in the dropzone BTICH");
            Destroy(dropZone.GetComponent<DropZoneFunctionality>().droppedItem);
            dropZone.GetComponent<DropZoneFunctionality>().itemDropped = false;
        }
    }

}
