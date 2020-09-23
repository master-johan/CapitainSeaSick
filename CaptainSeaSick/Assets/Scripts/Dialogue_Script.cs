using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Dialogue_Script : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    public float typingSpeed;
   
    

    IEnumerator Type()
    {
        foreach (var letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("TimeLine").GetComponentInChildren<ProgressBar_Script>().timeLeft < 110f)
        {
            GameObject.Find("Bubble").GetComponent<SpriteRenderer>().enabled = true;
            StartCoroutine(Type());
        }
        else
        {
            GameObject.Find("Bubble").GetComponent<SpriteRenderer>().enabled = false;
        }

       
    }

    public void NextScentence()
    {
        if(index < sentences.Length -1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
    }
}
