using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private Image foreGroundImage;
    [SerializeField] private float updateSpeedSeconds = 0.5f;
    private void Awake()
    {
        GameObject.FindGameObjectWithTag("Ship").GetComponent<ShipHealth>().healthPctChanged += HealthChange;
    }
    private void HealthChange(float percent)
    {
        StartCoroutine(ChangeToPercent(percent));
    }

    //Enumerator makes a smoother fill of the healthbar
    private IEnumerator ChangeToPercent(float percent)
    {
        float tempChangePercent = foreGroundImage.fillAmount;
        float tempTime = 0f;

        while (tempTime < updateSpeedSeconds)
        {
            tempTime += Time.deltaTime;
            foreGroundImage.fillAmount = Mathf.Lerp(tempChangePercent, percent, tempTime / updateSpeedSeconds);
            yield return null;
        }
        foreGroundImage.fillAmount = percent;
    }
}
