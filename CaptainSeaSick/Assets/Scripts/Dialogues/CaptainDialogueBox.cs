using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CaptainDialogueBox : MonoBehaviour
{
    public GameObject imageBox;
    public TextMeshProUGUI textBox;
    float currnetTimeTextShown;
    float timeTextShownMax = 5f;
    bool showingText;

    void Start()
    {
        DisableBox();
    }

    // Update is called once per frame
    void Update()
    {
        if (showingText)
        {
            TextTimer();
        }
    }

    private void TextTimer()
    {
        currnetTimeTextShown += Time.deltaTime;

        if (currnetTimeTextShown >= timeTextShownMax)
        {
            showingText = false;
            DisableBox();
        }
    }

    void DisableBox()
    {
        imageBox.SetActive(false);
    }
    void EnableBox()
    {
        imageBox.SetActive(true);
    }

    public void SetCurrentDialogue(string s)
    {
        Debug.Log(Time.time);
        if (!imageBox.activeSelf)
        {
            EnableBox();
        }
        textBox.text = s;
        currnetTimeTextShown = 0f;
        showingText = true;
    }

    public bool IsBusy()
    {
        return showingText;
    }
}
