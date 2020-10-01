using System.Collections;
using System.Collections.Generic;
using System.Security.Permissions;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class ProgressBar_Script : MonoBehaviour
{
    private Slider slider;
    public float levelTime = 120f; //2 MIN
    public float timeLeft; //How long left
    public float progress;

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

    // Update is called once per frame
    void Update()
    {
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
