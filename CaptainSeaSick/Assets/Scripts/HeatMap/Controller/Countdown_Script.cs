using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Countdown_Script : MonoBehaviour
{
    Animator animator;

    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }
    public void StartCountDown()
    {
        animator.SetBool("startCountDown", true);
    }
    public void SetCountDown()
    {
        GameAssets.instance.CountDownDone = true;
    }
}
