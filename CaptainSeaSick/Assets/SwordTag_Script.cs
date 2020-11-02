using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordTag_Script : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool CheckIfSwordIsReady()
    {
        if (transform.root.tag == "Player")
        {
            GameObject player = transform.root.gameObject;

            if (player.GetComponent<PlayerActions>().animator.GetCurrentAnimatorClipInfo(0)[0].clip.name == "Upward Thrust")
            {
                if (player.GetComponent<PlayerActions>().hasSword)
                {
                    return true;
                }
            }
        }
        return false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<BoardingEnemyScript>())
        {
            if (CheckIfSwordIsReady())
            {
                Destroy(other.gameObject);
            }
        }
    }
}
