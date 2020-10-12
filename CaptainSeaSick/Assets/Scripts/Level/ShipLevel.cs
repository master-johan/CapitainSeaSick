using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New ShipLevel", menuName = "ShipLevel")]
public class ShipLevel : ScriptableObject
{

    public List<Obstacle> obstacles;

}
