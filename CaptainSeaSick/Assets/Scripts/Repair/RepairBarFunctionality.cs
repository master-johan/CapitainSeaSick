using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairBarFunctionality : MonoBehaviour
{
    public Transform bar;

    // Start is called before the first frame update
    void Start()
    {
        bar = transform.Find("Bar");
        bar.localScale = new Vector3(0, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (bar.localScale.x >= 0)
        {
            bar.localScale -= new Vector3(0.005f, 0);
        }
        if (bar.localScale.x >= 1)
        {
            bar.localScale = new Vector3(1, 1);
        }

        
    }

    public void SetSize(float sizeNormalized)
    {
        bar.localScale += new Vector3(sizeNormalized, 0);
    }
}
