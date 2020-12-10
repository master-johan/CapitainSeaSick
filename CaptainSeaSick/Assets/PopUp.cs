using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUp : MonoBehaviour
{

    public GameObject topPos, botPos;
    public Animator animator;
    public float waveTimer, stayDownTimer;
    public float upSpeed, downSpeed;
    float resetWaveTimer, resetDownTimer;

    bool top = false;
    void Start()
    {
        resetWaveTimer = waveTimer;
        resetDownTimer = stayDownTimer;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y >= topPos.transform.position.y)
        {
            waveTimer -= Time.deltaTime;
            animator.SetBool("wave", true);

            if (waveTimer <= 0)
            {
                top = true;
                waveTimer = resetWaveTimer;
            }
        }
        if (transform.position.y <= botPos.transform.position.y)
        {
            stayDownTimer -= Time.deltaTime;
            animator.SetBool("wave", false);


            if (stayDownTimer <= 0)
            {
                top = false;
                stayDownTimer = resetDownTimer;

                float newXpos = Random.Range(-40, 40);
                transform.position = new Vector3(newXpos, transform.position.y, transform.position.z);
                topPos.transform.position = new Vector3(newXpos, topPos.transform.position.y, topPos.transform.position.z);
                botPos.transform.position = new Vector3(newXpos, botPos.transform.position.y, botPos.transform.position.z);
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
