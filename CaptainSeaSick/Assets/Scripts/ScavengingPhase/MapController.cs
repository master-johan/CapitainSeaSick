using System.Collections;
using System.Collections.Generic;
using System.Xml;
using TMPro;
using UnityEngine;

public class MapController : MonoBehaviour
{
    GameObject hiddenDoor;
    GameObject dropZone;
    GameObject pressurePlate;

    public TextMeshProUGUI text;

    int planks, cannonBalls, gold;
    Vector3 hiddenDoorDirection;
    private bool dirRight = true;
    float wallSpeed = 2.0f;
    public float levelTime = 20; //2 MIN
    public float timeLeft; //How long left
    float progress = 100;


    private void Start()
    {
        pressurePlate = GameObject.Find("PressurePlate");
        hiddenDoor = GameObject.Find("HiddenDoor");
        dropZone = GameObject.Find("DropZone");

        hiddenDoorDirection = new Vector3(0, 1, 0);

        timeLeft = levelTime;
    }
    void Update()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
        }
        progress = Mathf.RoundToInt(timeLeft * 100);

        text.text = "Gold " + gold + "\t" + " Planks: " + planks + "\t" + " Cannonballs: " + cannonBalls + "\t" + "\t"+ "\t" + "\t" + "Time Left: " + timeLeft;

        ChanceScene();
        //if (hiddenDoor != null)
        //{
        //    if (dirRight)
        //        hiddenDoor.transform.Translate(Vector2.right * wallSpeed * Time.deltaTime);
        //    else
        //        hiddenDoor.transform.Translate(-Vector2.right * wallSpeed * Time.deltaTime);

        //    if (hiddenDoor.transform.localPosition.x >= 60.0f)
        //    {
        //        dirRight = false;
        //    }

        //    if (hiddenDoor.transform.localPosition.x <= 38)
        //    {
        //        dirRight = true;
        //    }
        //}

        if (pressurePlate.GetComponent<PressurePlateTrigger>().plateIsTriggered && hiddenDoor.transform.localPosition.y >= -45)
        {
            hiddenDoor.transform.position -= hiddenDoorDirection * 2 * Time.deltaTime;
        }
        else if (!pressurePlate.GetComponent<PressurePlateTrigger>().plateIsTriggered && hiddenDoor.transform.localPosition.y <= -19)
        {
            hiddenDoor.transform.position += hiddenDoorDirection * 4 * Time.deltaTime;
        }

        if (dropZone.GetComponent<DropZoneFunctionality>().droppedItem != null)
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

                Destroy(dropZone.GetComponent<DropZoneFunctionality>().droppedItem);
                dropZone.GetComponent<DropZoneFunctionality>().itemDropped = false;
            }
        }
    }

    private void ChanceScene()
    {
        if (timeLeft <= 0)
        {
            GameObject.Find("LevelLoader").GetComponent<LevelLoader>().LoadNextLevel(); // Changing scene
        }
    }
}
