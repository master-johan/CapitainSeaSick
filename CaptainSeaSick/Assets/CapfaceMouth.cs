using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CapfaceMouth : MonoBehaviour
{

    [SerializeField]
    List<Sprite> sprites;
    Image image;
    public float  loopTimer;
    float currentTimer;
    int currentPic;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        currentTimer = loopTimer;
        currentPic = 0;
        image.sprite = sprites[currentPic];
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        currentTimer -= Time.fixedDeltaTime;

        if (currentTimer <= 0)
        {
            ChangePic();
        }
    }

    private void ChangePic()
    {
        currentPic++;
        image.sprite = sprites[currentPic % 3];
        currentTimer = loopTimer;
    }
}
