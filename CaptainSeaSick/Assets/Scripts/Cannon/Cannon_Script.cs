using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon_Script : MonoBehaviour
{
    public enum CannonState{ unloaded, loaded, canFire, fire}
    public CannonState cannonState;
    public GameObject cannonBall;

    public bool isShot;
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
                break;
            case CannonState.canFire:
                break;
            case CannonState.fire:
                Fire();
                break;
            default:
                break;
        }

    }
    private void Fire()
    {
        cannonBall.GetComponent<CannonBall>().isLoaded = false;
        cannonBall.GetComponent<CannonBall>().isShot = true;
        cannonBall.GetComponent<MeshRenderer>().enabled = true;
        cannonBall = null;
        cannonState = CannonState.unloaded;
    }

    public void SetCannonBall(GameObject cannonBall)
    {
        this.cannonBall = cannonBall;
    }
}
