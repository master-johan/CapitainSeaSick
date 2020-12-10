using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpAbe : MonoBehaviour
{
    public GameObject topPos, botPos;
    public Animator animator;
    public float waveTimer, stayDownTimer;
    public float upSpeed, downSpeed;
    float resetWaveTimer, resetDownTimer, startTimer;

    bool top = false;
    void Start()
    {
        startTimer = Random.Range(3, 5);
        resetWaveTimer = waveTimer;
        resetDownTimer = stayDownTimer;
    }

    // Update is called once per frame
    void Update()
    {
        startTimer -= Time.deltaTime;

        if(startTimer <= 0)
        {
            if (transform.position.x <= topPos.transform.position.x)
            {
                waveTimer -= Time.deltaTime;
                animator.SetBool("wave", true);

                if (waveTimer <= 0)
                {
                    top = true;
                    waveTimer = resetWaveTimer;
                }
            }
            if (transform.position.x >= botPos.transform.position.x)
            {
                stayDownTimer -= Time.deltaTime;
                animator.SetBool("wave", false);


                if (stayDownTimer <= 0)
                {
                    top = false;
                    stayDownTimer = resetDownTimer;

                    float newYpos = Random.Range(-40, 40);
                    transform.position = new Vector3(transform.position.x, newYpos, transform.position.z);
                    topPos.transform.position = new Vector3(topPos.transform.position.x, newYpos, topPos.transform.position.z);
                    botPos.transform.position = new Vector3(botPos.transform.position.x, newYpos, botPos.transform.position.z);
                }
            }
            if (top)
            {
                transform.position = Vector3.MoveTowards(transform.position, botPos.transform.position, downSpeed * Time.deltaTime);
            }
            else if (!top)
            {
                transform.position = Vector3.MoveTowards(transform.position, topPos.transform.position, upSpeed * Time.deltaTime);
            }
        }
       
    }
}
