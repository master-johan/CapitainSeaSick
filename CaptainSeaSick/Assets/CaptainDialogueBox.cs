using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CaptainDialogueBox : MonoBehaviour
{
    public GameObject imageBox;
    public TextMeshProUGUI textBox;
    float timeTextShown;
    bool showingText;
    void Start()
    {
        disableBox();
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
        timeTextShown += Time.deltaTime;

        if (timeTextShown >= 5)
        {
            showingText = false;
            disableBox();
        }
    }

    void disableBox()
    {
        imageBox.SetActive(false);
    }
    void enableBox()
    {
        imageBox.SetActive(true);
    }

    public void SetCurrentDialogue(string s)
    {
        if (!imageBox.activeSelf)
        {
            enableBox();
        }
        textBox.text = s;
        timeTextShown = 0f;
        showingText = true;
    }
}
