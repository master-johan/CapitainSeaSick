using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon_Script : MonoBehaviour
{
    public enum CannonState{ unloaded, loaded, canFire}
    public CannonState cannonState;
    // Start is called before the first frame update
    void Start()
    {
        cannonState = CannonState.unloaded;
    }

    // Update is called once per frame
    void Update()
    {
        switch (cannonState)
        {
            case CannonState.unloaded:
                break;
            case CannonState.loaded:
                Debug.Log("cannon loaded");
                break;
            case CannonState.canFire:
            default:
                break;
        }

    }
}
