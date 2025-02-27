﻿using System.Collections;
using System.Collections.Generic;
using System.Security.Permissions;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ProgressBar_Script : MonoBehaviour
{
    private Slider slider;
    public GameObject controllerMenuSystem;
    private float levelTime;
    public float timeLeft; //How long left
    public float progress = 100;
    public bool isDone = false;
    public GameObject timelineObstacle;
    public List<GameObject> obstaclesInTimeLine;
    List<TimeLineObstacle> obstaclesSpotted;

    public float TimeLeft { get => timeLeft; set => timeLeft = value; }

    private Image imageBoat;
    private bool seeFar;

    private int sightLength;

    private UnityAction seeFarListner, seeRegularListner;

    private void OnEnable()
    {
        EventManager.StartSubscribe("ManInNest", seeFarListner);
        EventManager.StartSubscribe("ManNotInNest", seeRegularListner);
    }
    private void Awake()
    {
        slider = gameObject.GetComponent<Slider>();
        imageBoat = gameObject.GetComponentInChildren<Image>();
        obstaclesSpotted = new List<TimeLineObstacle>();
        seeFarListner = new UnityAction(ExtendedSightLenght);
        seeRegularListner = new UnityAction(RegularSightLenght);
    }
    void Start()
    {
        levelTime = GameObject.Find("LevelManager").GetComponent<LevelManager>().currentLevel.LevelTime;
        timeLeft = levelTime;
        slider.value = timeLeft;
    }
    void Update()
    {

        if(progress <= 0)
        {
            GameObject.Find("LevelLoader").GetComponent<LevelLoader>().LoadNextLevel();

            //SceneManager.LoadScene(1);
        }
        if (GameAssets.instance.playersReady)
        {
            controllerMenuSystem.SetActive(false);
            if (timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
                slider.value = timeLeft / levelTime;
                 
            }
            else
            {
                Time.timeScale = 0;
            }
            progress = Mathf.RoundToInt(slider.value * 100.0f);


        }

        CheckToSeeObstaclesOnTimeLine();
 
    }

    public void SetIndicatorsOnTimeLine(List<Obstacle> obstacles)
    {
        
        foreach (var obstacle in obstacles)
        {
            Vector3 place = Vector3.zero;
            float x = (GetComponent<RectTransform>().rect.width * GetComponent<RectTransform>().localScale.x) * (1- ((float)obstacle.whenToSpawn / 100));
            place.x = x;
            place.y = 40;
            GameObject tempObject;
            tempObject = Instantiate(timelineObstacle,gameObject.transform);
            tempObject.GetComponent<RectTransform>().transform.position += place;
            tempObject.GetComponent<TimeLineObstacle>().SetObstacle = obstacle;
            obstaclesInTimeLine.Add(tempObject);
        }
    }

    private void ExtendedSightLenght()
    {
        if (!seeFar)
        {
            seeFar = true;
            sightLength = 50;
        }
    }

    private void RegularSightLenght()
    {
        if (seeFar)
        {
            seeFar = false;
            sightLength = 0;
            ResetSpottedList();
         
        }
    }

    private void CheckToSeeObstaclesOnTimeLine()
    {
        int currentSeeLenght = Mathf.RoundToInt(progress - sightLength);

        foreach (var item in obstaclesInTimeLine)
        {
            TimeLineObstacle tO = item.GetComponent<TimeLineObstacle>();
            if (tO.currentStatus == TimeLineObstacleStatus.unknown)
            {
                if (tO.positionOnTimeLine > currentSeeLenght)
                {
                    tO.ChangeStatus(TimeLineObstacleStatus.known);
                    AddToListIfNotAdded(tO);
                }
            }
        }
    }

    private void ResetSpottedList()
    {
        int currentSeeLenght = Mathf.RoundToInt(progress - sightLength);
        if (obstaclesSpotted.Count > 0)
        {
            foreach (var item in obstaclesSpotted)
            {
                if (item.positionOnTimeLine < currentSeeLenght)
                {
                    item.ChangeStatus(TimeLineObstacleStatus.unknown);
                }
            }
        }
        obstaclesSpotted.Clear();
    }
    private void AddToListIfNotAdded(TimeLineObstacle tO)
    {
        if (obstaclesSpotted.Count ==0)
        {
            obstaclesSpotted.Add(tO);
        }
        else
        {
            bool foundInList = false;
            foreach (var item in obstaclesSpotted)
            {
                if (tO == item)
                {
                    foundInList = true;
                    break;
                }
            }

            if (!foundInList)
            {
                obstaclesSpotted.Add(tO);
            }
        }
    }

}
