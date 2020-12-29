using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WorkbenchStates { NeedMats, CanBeCrafted, IsCrafted }
public class WorkBeanch : MonoBehaviour
{
    public GameObject plankBandaid, QuarterBar, CraftBar;
    public WorkbenchStates currentState;
    GameObject[] plankSpots;
    GameObject tempPlank;
    List<GameObject> plankList;
    int counter;
    bool canBeCrafted;

    void Start()
    {
        plankList = new List<GameObject>();
        plankSpots = new GameObject[4];
        plankSpots[0] = GameObject.Find("Spot1");
        plankSpots[1] = GameObject.Find("Spot2");
        plankSpots[2] = GameObject.Find("Spot3");
        plankSpots[3] = GameObject.Find("Spot4");

        currentState = WorkbenchStates.NeedMats;


    }


    void FixedUpdate()
    {
        switch (currentState)
        {
            case WorkbenchStates.NeedMats:              
                ChangeBarState();
                break;

            case WorkbenchStates.CanBeCrafted:
                CraftBar.SetActive(true);
                CheckIfCompleted();
                break;

            case WorkbenchStates.IsCrafted:
                CraftBar.SetActive(false);
                InstansiateBandaid();
                currentState = WorkbenchStates.NeedMats;
                break;

            default:
                break;
        }
    }

    private void InstansiateBandaid()
    {
        for (int i = 3; i >= 0; i--)
        {
            Destroy(plankList[i].gameObject);
            plankList.RemoveAt(i);
        }
        Instantiate(plankBandaid, plankSpots[3].transform.position, Quaternion.identity);
    }
    public void CraftBandaid()
    {
        GetComponentInChildren<RepairBarFunctionality>().SetSize(0.1f);
    }
    private void CheckIfCompleted()
    {
        if (CraftBar.GetComponent<RepairBarFunctionality>().bar.localScale.x >= 1)
        {
            currentState = WorkbenchStates.IsCrafted;
        }
    }
    private void ChangeBarState()
    {
        if (plankList.Count == 1)
        {
            QuarterBar.GetComponent<QuarterBar_Functionality>().currentState = BarState.OneQuarter;
        }
        else if (plankList.Count == 2)
        {
            QuarterBar.GetComponent<QuarterBar_Functionality>().currentState = BarState.Half;
        }
        else if (plankList.Count == 3)
        {
            QuarterBar.GetComponent<QuarterBar_Functionality>().currentState = BarState.ThreeQuarters;
        }
        else if (plankList.Count == 4)
        {
            QuarterBar.GetComponent<QuarterBar_Functionality>().currentState = BarState.Full;
        }
        else
        {
            QuarterBar.GetComponent<QuarterBar_Functionality>().currentState = BarState.Empty;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Plank_Script>() && !other.gameObject.GetComponent<Plank_Script>().isPickedUp)
        {
            tempPlank = other.gameObject;
            tempPlank.GetComponent<Rigidbody>().isKinematic = true;
            tempPlank.GetComponent<Rigidbody>().freezeRotation = true;
            tempPlank.GetComponent<Collider>().enabled = false;


            if (plankList.Count == 4)
            {
                QuarterBar.GetComponent<QuarterBar_Functionality>().currentState = BarState.Full;
                currentState = WorkbenchStates.CanBeCrafted;
            }
            else if (counter < 4)
            {
                if (other.isTrigger)
                {
                    tempPlank.transform.parent = plankSpots[counter].transform;
                    tempPlank.transform.position = plankSpots[counter].transform.position;
                    tempPlank.transform.forward = plankSpots[counter].transform.forward;

                    plankList.Add(tempPlank);

                    counter++;

                }
            }
        }
    }
}
