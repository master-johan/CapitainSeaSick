using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;
using UnityEngine.UI;

public class SelectButtonOnMenuSwap : MonoBehaviour
{
    public EventSystem eventSystem;

    public GameObject selectedButton;
    bool once;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SelectButton()
    {
        eventSystem.SetSelectedGameObject(selectedButton);
    }
}
