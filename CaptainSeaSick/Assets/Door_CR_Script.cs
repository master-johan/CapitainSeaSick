﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_CR_Script : MonoBehaviour
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
        DoorAnimator.SetTrigger("Open");
        GetComponentInChildren<BoxCollider>().enabled = false;
    }
}
