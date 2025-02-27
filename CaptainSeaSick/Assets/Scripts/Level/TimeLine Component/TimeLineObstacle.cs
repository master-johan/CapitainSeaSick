﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Rendering.UI;
using UnityEngine.UI;


public enum TimeLineObstacleStatus { unknown, known, expired }
public class TimeLineObstacle : MonoBehaviour
{
    public TimeLineObstacleStatus currentStatus;
    [SerializeField]
    public Image currentImage;
    public Sprite unknownImage, shipImage, cliffImage;
    [HideInInspector]
    public int positionOnTimeLine;
    Obstacle obstacle;
    

    public Obstacle SetObstacle { get => obstacle; set => obstacle = value; }

    // Start is called before the first frame update
    void Start()
    {
        currentStatus = TimeLineObstacleStatus.unknown;
        currentImage = GetComponent<Image>();
        currentImage.sprite = unknownImage;
        positionOnTimeLine = obstacle.whenToSpawn;
    }

    // Update is called once per frame
    void Update()
    {
        TimeLineObstacleStatus obstacleStatus = obstacle.status;
        if (obstacleStatus != currentStatus)
        {
            ChangeStatus(obstacleStatus);
        }
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
        else if (status == TimeLineObstacleStatus.expired)
        {
            currentImage.color = Color.gray;
        }
        else if (status == TimeLineObstacleStatus.unknown)
        {
            currentImage.sprite = unknownImage;
        }
       

        currentStatus = status;
        obstacle.status = status;

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
