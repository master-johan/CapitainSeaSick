using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WeatherManager_Script : MonoBehaviour
{

   

    public RainSwitch rain;
    public GameObject wind;
    public CloudSwitch cloud;
    public LightSwitch light;


    string rainStart = "rainStart";
    string rainStop = "rainsStop";
    string lightStart = "lightStart";
    string lightStop = "lightStop";
    string cloudStart = "cloudStart";
    string cloudStop = "cloudStop";
    string windStart = "windStart";
    string windStop = "windStop";

    UnityAction rainStartAction;
    UnityAction rainStopAction;

    UnityAction lightStartAction;
    UnityAction lightStopAction;

    UnityAction cloudStartAction;
    UnityAction cloudStopAction;

    UnityAction windStartAction;
    UnityAction windStopAction;





    private void OnEnable()
    {
        Debug.Log("Am i called? on enable");
        EventManager.StartSubscribe(rainStart, rainStartAction);
        EventManager.StartSubscribe(rainStop, rainStopAction);

        EventManager.StartSubscribe(lightStart, lightStartAction);
        EventManager.StartSubscribe(lightStop, lightStopAction);

        EventManager.StartSubscribe(cloudStart, cloudStartAction);
        EventManager.StartSubscribe(cloudStop, cloudStopAction);

        EventManager.StartSubscribe(windStart, windStartAction);
        EventManager.StartSubscribe(windStop, windStopAction);
    }

    private void OnDisable()
    {
        Debug.Log("Am i called? on enable");
        EventManager.StopSubscribe(rainStart, rainStartAction);
        EventManager.StopSubscribe(rainStop, rainStopAction);

        EventManager.StopSubscribe(lightStart, lightStartAction);
        EventManager.StopSubscribe(lightStop, lightStopAction);

        EventManager.StopSubscribe(cloudStart, cloudStartAction);
        EventManager.StopSubscribe(cloudStop, cloudStopAction);

        EventManager.StopSubscribe(windStart, windStartAction);
        EventManager.StopSubscribe(windStop, windStopAction);
    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Am i called? start " );
        rainStartAction = new UnityAction(StartRain);
        rainStopAction = new UnityAction(StopRain);

        lightStartAction = new UnityAction(LightStart);
        lightStopAction = new UnityAction(LightStop);

        cloudStartAction = new UnityAction(CloudStart);
        cloudStopAction = new UnityAction(CloudStop);

        windStartAction = new UnityAction(WindStart);
        windStopAction = new UnityAction(WindStop); 
    }

    // Update is called once per frame
    void Update()
    {

    }

    void StartRain()
    {
        Debug.Log("rain is called");
        rain.rainOn = true;
    }
    void StopRain()
    {
        rain.rainOn = false;
    }

    void LightStart()
    {
        light.switchLight = true;
    }
    void LightStop()
    {
        light.switchLight = false;
    }

    void WindStart()
    {
        wind.GetComponent<Wind_Functionality>().ActivateWind();
    }
    void WindStop()
    {
        wind.GetComponent<Wind_Functionality>().DeactivateWind();
    }

    void CloudStart()
    {
        cloud.startHeavyClouds = true;
    }
    void CloudStop()
    {
        cloud.startHeavyClouds = false;
    }
}
