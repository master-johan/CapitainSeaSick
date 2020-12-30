using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum BarState { Empty, OneQuarter, Half, ThreeQuarters, Full }
public class QuarterBar_Functionality : MonoBehaviour
{
    public Transform bar;
    public BarState currentState;
    // Start is called before the first frame update
    void Start()
    {
        bar.localScale = new Vector3(0, 1);
    }

    // Update is called once per frame
    void Update()
    {
        SetBarAmount();
    }
    public void SetBarAmount()
    {
        switch (currentState)
        {
            case BarState.Empty:
                bar.localScale = new Vector3(0, 1);
                break;
            case BarState.OneQuarter:
                bar.localScale = new Vector3(0.25f, 1);
                break;
            case BarState.Half:
                bar.localScale = new Vector3(0.5f, 1);
                break;
            case BarState.ThreeQuarters:
                bar.localScale = new Vector3(0.75f, 1);
                break;
            case BarState.Full:
                bar.localScale = new Vector3(1, 1);
                break;
            default:
                break;
        }
    }
}
