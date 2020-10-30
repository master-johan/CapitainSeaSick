using System.Collections;
using System.Collections.Generic;
using System.Security.Permissions;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class ProgressBar_Script : MonoBehaviour
{
    private Slider slider;
    public GameObject controllerMenuSystem;
    public float levelTime = 20; //2 MIN
    public float timeLeft; //How long left
    public float progress = 100;
    public bool isDone = false;
    public GameObject timelineObstacle;

    public float TimeLeft { get => timeLeft; set => timeLeft = value; }
    public float LevelTime { get => levelTime; set => levelTime = value; }

    private Image imageBoat;

    private void Awake()
    {
        slider = gameObject.GetComponent<Slider>();
        imageBoat = gameObject.GetComponentInChildren<Image>();
        
    }
    void Start()
    {
        
        timeLeft = LevelTime;
        slider.value = timeLeft;
    }
    void Update()
    {
        if(ControllerMenuJoinScript.playerReady)
        {
            controllerMenuSystem.SetActive(false);
            if (timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
                slider.value = timeLeft / LevelTime;
            }
            else
            {
                Time.timeScale = 0;
            }
            progress = Mathf.RoundToInt(slider.value * 100);
        }
    }

    public void SetIndicatorsOnTimeLine(List<Obstacle> obstacles)
    {
        foreach (var obstacle in obstacles)
        {
            Vector3 place = Vector3.zero;
            float x = (GetComponent<RectTransform>().rect.width * GetComponent<RectTransform>().localScale.x) * (1- ((float)obstacle.whenToSpawn / 100));
            place.x = x;

            GameObject tempObject;
            tempObject = Instantiate(timelineObstacle,gameObject.transform);
            tempObject.GetComponent<RectTransform>().transform.position += place;

        }
    }
}
