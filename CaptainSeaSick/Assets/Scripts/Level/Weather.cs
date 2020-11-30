using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TypeOfWeather { rain, light, cloud, wind}
[Serializable]
public class Weather 
{
    public TypeOfWeather weather;
    public int whenToSpawn;
    public int whenToStop;
    [HideInInspector]
    public bool active = false;
    
}
