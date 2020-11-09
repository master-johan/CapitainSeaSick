using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScavengingManager : MonoBehaviour
{
    [Tooltip("Resources")]
    int Plank, CannonBall, Gold;
    private float timeLeft;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI goldText;
    private int progress;


    void Start()
    {
        timeLeft = GameAssets.instance.ScavLevelTimer1;
    }
    void Update()
    {
        UpdateLevelTimer();
        UpdateGold();
        GameObject.Find("DropZone_Trigger").GetComponent<DropZoneFunctionality>().DropZoneUpdate();
    }

    private void UpdateLevelTimer()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            progress = Mathf.RoundToInt(timeLeft);
            timeText.text = "Time Left : " + "\t" + progress;
        }
        else
        {
            GameObject.Find("LevelLoader").GetComponent<LevelLoader>().LoadNextLevel();
        }
    }

    private void UpdateGold()
    {
        goldText.text = "Gold : " + GameAssets.instance.gold;
    }

}
