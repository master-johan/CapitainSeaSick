using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Button_Indicator_Script : MonoBehaviour
{
    public enum ButtonIndicator 
    { 
        Ybtn,
        Xbtn,
        Abtn,
        Bbtn, 
        Nobtn
    }

    public Sprite YbtnIMG;
    public Sprite XbtnIMG;
    public Sprite AbtnIMG;
    public Sprite BbtnIMG;

    void Update()
    {
        ChangeIndicator();
    }
    public ButtonIndicator currentIndicator = ButtonIndicator.Ybtn;
    public void ChangeIndicator()
    {
        switch (currentIndicator)
        {
            case ButtonIndicator.Ybtn :
                GetComponent<Image>().sprite = YbtnIMG;
                break;
            case ButtonIndicator.Xbtn:
                GetComponent<Image>().sprite = XbtnIMG;
                break;
            case ButtonIndicator.Abtn:
                GetComponent<Image>().sprite = AbtnIMG;
                break;
            case ButtonIndicator.Bbtn:
                GetComponent<Image>().sprite = BbtnIMG;
                break;
        }
    }
}
