using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScavengingManager : MonoBehaviour
{
    [Tooltip("Resources")]
    int Gold;
    private float timeLeft;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI goldText;
    private int progress;
    public List<GameObject> goldList;
    float threshold;


    void Start()
    {
        timeLeft = GameAssets.instance.ScavLevelTimer1;
        goldList = GameObject.FindGameObjectsWithTag("PickableObject").ToList();
        RemoveKeyAndBucket();
        threshold = GameAssets.instance.ScavLevelTimer1 - 10;
    }

    private void RemoveKeyAndBucket()
    {
        for (int i = goldList.Count -1; i >= 0; i--)
        {
            if (!goldList[i].GetComponent<ResourceTag>())
            {
                goldList.RemoveAt(i);
            }
        }
    }

    void Update()
    {
        if (goldList.Count == 0 && timeLeft < threshold)
        {
            GameObject.Find("HeatmapTool").GetComponent<GridTest>().PrintData();
            GameObject.Find("LevelLoader").GetComponent<LevelLoader>().LoadShopLevel();
        }
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
            GameAssets.instance.playersReady = false;

            GameObject.Find("LevelLoader").GetComponent<LevelLoader>().LoadShopLevel();
        }
    }

    private void UpdateGold()
    {
        goldText.text = "Gold : " + GameAssets.instance.gold;
    }

    public float GetTimeleft()
    {
        return timeLeft;
    }

}
