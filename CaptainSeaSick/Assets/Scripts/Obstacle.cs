using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum TypeOfSpawn
{
    cliff, ship, random
}
[Serializable]
public class Obstacle
{
    public TypeOfSpawn type;
    public int whenToSpawn;
    public int numberOfSpawns;
    public float timeBetweenSpawn;
}
