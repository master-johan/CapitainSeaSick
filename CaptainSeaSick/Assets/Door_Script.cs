using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Script : MonoBehaviour
{
    public Animator DoorAnimator;
    // Start is called before the first frame update
    void Start()
    {
        DoorAnimator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {        
    }
    public void OpenDoor()
    {
        DoorAnimator.SetBool("OpenDoor", true);
        SoundManager.Instance.PlaySoundEffect(GameAssets.instance.soundEffects[0], 0.7f);
        GetComponentInChildren<BoxCollider>().enabled = false;
       
    }

    public void CloseDoor()
    {
        DoorAnimator.SetBool("OpenDoor", false);
        GetComponentInChildren<BoxCollider>().enabled = true;
    }
}
