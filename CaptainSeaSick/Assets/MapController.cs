using System.Collections;
using System.Collections.Generic;
using System.Xml;
using TMPro;
using UnityEngine;

public class MapController : MonoBehaviour
{
    GameObject movingWall;
    GameObject dropZone;

    int planks, cannonBalls, gold;

    private bool dirRight = true;
    float wallSpeed = 2.0f;


    private void Start()
    {
        movingWall = GameObject.Find("MovingWall");
        dropZone = GameObject.Find("DropZone");
    }
    void Update()
    {
        if (movingWall != null)
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
        }
        if(dropZone.GetComponent<DropZoneFunctionality>().droppedItem != null)
        {
            if (dropZone.GetComponent<DropZoneFunctionality>().itemDropped)
            {
                if (dropZone.GetComponent<DropZoneFunctionality>().droppedItem.GetComponent<GoldCoinTag>())
                {
                    gold++;
                }
                if (dropZone.GetComponent<DropZoneFunctionality>().droppedItem.GetComponent<PlankTag>())
                {
                    planks++;
                }
                if (dropZone.GetComponent<DropZoneFunctionality>().droppedItem.GetComponent<CannonBall>())
                {
                    cannonBalls++;
                }
                Debug.Log("Gold:" + gold +  " planks: " + planks + " Cannonballs: " + cannonBalls);
                Destroy(dropZone.GetComponent<DropZoneFunctionality>().droppedItem);
                dropZone.GetComponent<DropZoneFunctionality>().itemDropped = false;
            }
        }
    }
}
