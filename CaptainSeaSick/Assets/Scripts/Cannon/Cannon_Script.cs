using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon_Script : MonoBehaviour
{
    public enum CannonState{ unloaded, loaded, canFire, fire}
    public CannonState cannonState;
    public GameObject cannonBall;
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
    /// <summary>
    /// When a cannon is fired, it's cannonball changes isLoaded to false, isShot to true and its renderer to true so it can be seen.
    /// The cannon doesn't have a cannonball attached to it and the state of the cannon goes to unloaded.
    /// </summary>
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
