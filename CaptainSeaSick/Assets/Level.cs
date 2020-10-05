using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "New Level", menuName = "ShipLevel")]
public class Level : ScriptableObject
{
    public int difficulty;
    [SerializeField]
    public List<Obstacle> obstacles;
 

}
