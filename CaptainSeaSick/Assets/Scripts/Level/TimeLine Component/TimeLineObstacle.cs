using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;


public enum TimeLineObstacleStatus { unknown, known, expired }
public class TimeLineObstacle : MonoBehaviour
{
    TimeLineObstacleStatus currentStatus;
    [SerializeField]
    public Image currentImage;
    public Sprite unknownImage, shipImage, cliffImage;
    Obstacle obstacle;
    

    public Obstacle SetObstacle { get => obstacle; set => obstacle = value; }

    // Start is called before the first frame update
    void Start()
    {
        currentStatus = TimeLineObstacleStatus.unknown;
        currentImage = GetComponent<Image>();
        currentImage.sprite = unknownImage;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeStatus(TimeLineObstacleStatus status)
    {
        if (currentStatus == status)
        {
            return;
        }
        else if (status == TimeLineObstacleStatus.known)
        {
            currentImage.sprite = GetImage(obstacle.type);
 
        }

        currentStatus = status;

    }

    private Sprite GetImage(TypeOfSpawn type)
    {
        if (type == TypeOfSpawn.cliff)
        {
            return cliffImage;
        }
        else if (type == TypeOfSpawn.ship)
        {
            return shipImage;
        }
        return unknownImage;
    }
}
