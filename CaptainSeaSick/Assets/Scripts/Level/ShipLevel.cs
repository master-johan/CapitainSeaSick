using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New ShipLevel", menuName = "ShipLevel")]
public class ShipLevel : ScriptableObject
{
    public int LevelTime;
    public List<Obstacle> obstacles;
    public List<Weather> weathers;
}
