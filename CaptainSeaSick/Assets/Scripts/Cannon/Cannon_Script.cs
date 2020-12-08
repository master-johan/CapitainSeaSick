using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon_Script : MonoBehaviour
{
    public enum CannonState{ unloaded, loaded, canFire, fire}
    public CannonState cannonState;
    public GameObject cannonBall, buttonB;
    public BoxCollider pickUpZone;
    public ParticleSystem fireEffect;
    public bool onSpot = false;

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
                buttonB.SetActive(false);
                break;
            case CannonState.loaded:
                buttonB.SetActive(false);
                break;
            case CannonState.canFire:
                buttonB.SetActive(true);
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
    public void Fire()
    {
        SoundManager.Instance.PlaySoundEffect(GameAssets.instance.soundEffects[8], 0.5f);
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

    private void OnTriggerExit(Collider other)
    {
        //if (other.tag == "Player")
        //{
        //    PlayerActions pa = other.GetComponent<PlayerActions>();
        //    if (pa.focusedObject = gameObject)
        //    {
        //        pa.SetFocus(null, 0, 0);
        //    }
        //}
    }

    void OnTriggerEnter(Collider other)
    {
     
        //if (other.tag == "Player")
        //{

        //    other.GetComponent<PlayerActions>().SetFocus(gameObject, GetComponent<OffsetScript>().offsetX, GetComponent<OffsetScript>().offsetY);

        //}
    }

    public void ChangeStateToFire()
    {
        if (cannonState == CannonState.canFire)
        {   
            Instantiate(fireEffect, transform.Find("CannonBallOffset").transform.position, transform.Find("CannonBallOffset").transform.rotation);
           
            cannonState = CannonState.fire;
        }
    }
}
