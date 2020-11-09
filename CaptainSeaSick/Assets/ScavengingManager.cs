using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScavengingManager : MonoBehaviour
{
    [Tooltip("Resources")]
    int Plank, CannonBall, Gold;
    private float timeLeft;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI goldText;

    GameObject dropZone;

    void Start()
    {
        dropZone = GameAssets.instance.dropZonePrefab;
        timeLeft = GameAssets.instance.ScavLevelTimer1;
    }
    void Update()
    {
        UpdateLevelTimer();
        UpdateGold();
        DropZoneUpdate();
    }

    private void UpdateLevelTimer()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            timeText.text = "Time Left : " + "\t" + timeLeft;
        }
    }

    private void UpdateGold()
    {
        goldText.text = "Gold : ";
    }
    private void DropZoneUpdate()
    {
        if (dropZone.GetComponent<DropZoneFunctionality>().droppedItem != null)
        {
            //Adds a point to the different resource values depending on which item is dropped in the dropzone.
            if (dropZone.GetComponent<DropZoneFunctionality>().itemDropped)
            {
                if (dropZone.GetComponent<DropZoneFunctionality>().droppedItem.GetComponent<GoldCoinTag>())
                {
                    Gold++;
                }
                if (dropZone.GetComponent<DropZoneFunctionality>().droppedItem.GetComponent<PlankTag>())
                {
                    Plank++;
                }
                if (dropZone.GetComponent<DropZoneFunctionality>().droppedItem.GetComponent<CannonBall>())
                {
                    CannonBall++;
                }

                //Destroy the item that lands in the dropzone and reset the bool.
                Destroy(dropZone.GetComponent<DropZoneFunctionality>().droppedItem);
                dropZone.GetComponent<DropZoneFunctionality>().itemDropped = false;
            }
        }
    }
}
