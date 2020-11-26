using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]

public class FlashImage : MonoBehaviour
{
    Image image = null;
    Coroutine currentFlash = null;
    private void Awake()
    {
        image = GetComponent<Image>();
    }

    public void StartFlash(float secondsForFlash, float maxAlpha, Color newColor)
    {
        image.color = newColor;
        maxAlpha = Mathf.Clamp(maxAlpha, 0, 1);

        if (currentFlash != null)
        {
            StopCoroutine(currentFlash);
            currentFlash = StartCoroutine(Flash(secondsForFlash, maxAlpha));
        }
    }
    public void StopFlash(float secondsForFlash, float maxAlpha, Color newColor)
    {
        image.color = newColor;
        maxAlpha = Mathf.Clamp(maxAlpha, 0, 1);
        if (currentFlash != null)
        {
            currentFlash = StartCoroutine(StopFlashRoutine(secondsForFlash, maxAlpha));
        }
           

    }

    IEnumerator StopFlashRoutine(float secondsForFlash, float maxAlpha)
    {
        float flashOutDuration = secondsForFlash / 2;
        for (float time = 0; time <= flashOutDuration; time += Time.deltaTime)
        {
            Color colorTemp = image.color;
            colorTemp.a = Mathf.Lerp(maxAlpha, 0, time / flashOutDuration);
            image.color = colorTemp;
            yield return null;
        }

        //Reset alpha to zero
        image.color = new Color32(0, 0, 0, 0);
    }

    IEnumerator Flash(float secondsForFlash, float maxAlpha)
    {
        //Animate Flash in
        float flashInDuration = secondsForFlash / 2;
        for (float time = 0; time <= flashInDuration; time+= Time.deltaTime)
        {
            Color colorTemp = image.color;
            colorTemp.a = Mathf.Lerp(0, maxAlpha, time / flashInDuration);
            image.color = colorTemp;
            //Wait for next frame
            yield return null;
        }
        //Animate Flash out

    }

}
