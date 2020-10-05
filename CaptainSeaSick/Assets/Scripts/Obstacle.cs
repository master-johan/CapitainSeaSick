using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]

public enum TypeOfSpawn
{
    cliff, ship, random
}
[CreateAssetMenu(fileName = "New Obstacle", menuName = "Obstacle")]
public class Obstacle : ScriptableObject
{
    public int numberOfSpawns;
    public int whenToSpawn;
    public float timeBetweenSpawn;
    public TypeOfSpawn type;
}
