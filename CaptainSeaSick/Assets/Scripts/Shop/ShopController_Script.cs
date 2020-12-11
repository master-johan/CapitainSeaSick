using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShopController_Script : MonoBehaviour
{
    public GameObject cannonText;
    public GameObject goldText;
    public GameObject cannonBallDamageText;
    public GameObject swordsText;
    public GameObject shipHealthpointsText;

    // Start is called before the first frame update
    void Start()
    {
        cannonText.GetComponent<TextMeshProUGUI>().text = GameAssets.instance.numberOfCannons.ToString();
        goldText.GetComponent<TextMeshProUGUI>().text = GameAssets.instance.gold.ToString();
        cannonBallDamageText.GetComponent<TextMeshProUGUI>().text = GameAssets.instance.cannonballsDamage.ToString(); 
        swordsText.GetComponent<TextMeshProUGUI>().text =  GameAssets.instance.numberOfSwords.ToString(); 
        shipHealthpointsText.GetComponent<TextMeshProUGUI>().text =  GameAssets.instance.ShipMaxHealth.ToString(); 
    }

    // Update is called once per frame
    void Update()
    {

        if (GameAssets.instance.cannonPrice > GameAssets.instance.gold && !GameAssets.instance.cannonFull)
        {
            GoldLimitReached("Cannon");
        }
        if (GameAssets.instance.swordPrice > GameAssets.instance.gold && !GameAssets.instance.swordFull)
        {
            GoldLimitReached("Sword");

        }
        if (GameAssets.instance.shipMaxHealthPrice > GameAssets.instance.gold && !GameAssets.instance.maxHealthFull)
        {
            GoldLimitReached("Health");
        }
        if (GameAssets.instance.cannonballDamagePrice > GameAssets.instance.gold && !GameAssets.instance.cannonDamageFull)
        {
            GoldLimitReached("Upgraded Cannonballs");
        }
    }


    public void BuyCannon()
    {
        if (GameAssets.instance.numberOfCannons < 4)
        {
            if (CheckGold(GameAssets.instance.cannonPrice))
            {
                GameAssets.instance.numberOfCannons++;

                cannonText.GetComponent<TextMeshProUGUI>().text = GameAssets.instance.numberOfCannons.ToString();
                if (GameAssets.instance.numberOfCannons == 4)
                {
                    LimitReached("Cannon");
                    GameAssets.instance.cannonFull = true;
                }
            }
           
        }
    }

    public void BuySword()
    {
        if (GameAssets.instance.numberOfSwords < 3)
        {
            if (CheckGold(GameAssets.instance.swordPrice))
            {
                GameAssets.instance.numberOfSwords++;

                swordsText.GetComponent<TextMeshProUGUI>().text = GameAssets.instance.numberOfSwords.ToString();
                if (GameAssets.instance.numberOfSwords == 3)
                {
                    LimitReached("Sword");
                    GameAssets.instance.swordFull = true;
                }
            }
            
        }
    }

    public void BuyHealth()
    {
        if (GameAssets.instance.ShipMaxHealth < 500)
        {
            if (CheckGold(GameAssets.instance.shipMaxHealthPrice))
            {
                GameAssets.instance.ShipMaxHealth += 50;

                shipHealthpointsText.GetComponent<TextMeshProUGUI>().text = GameAssets.instance.ShipMaxHealth.ToString();
                if (GameAssets.instance.ShipMaxHealth == 500)
                {
                    LimitReached("Health");
                    GameAssets.instance.maxHealthFull = true;
                }
            }
          
        }
    }

    public void CannonballDamage()
    {
        if (GameAssets.instance.cannonballsDamage < 20)
        {
            if (CheckGold(GameAssets.instance.cannonballDamagePrice))
            {
                GameAssets.instance.cannonballsDamage += (GameAssets.instance.cannonballsDamage / 100) * 25; //25% damage increase

                cannonBallDamageText.GetComponent<TextMeshProUGUI>().text = Math.Round(GameAssets.instance.cannonballsDamage).ToString(); 
                if (GameAssets.instance.cannonballsDamage == 20)
                {
                    LimitReached("Upgraded Cannonballs");
                    GameAssets.instance.cannonDamageFull = true;
                }
            }
            
        }
    }

    public void NextLevel()
    {
        GameObject.Find("LevelLoader").GetComponent<LevelLoader>().LoadLevelMap();
    }

    private bool CheckGold(int itemPrice)
    {
        if (itemPrice <= GameAssets.instance.gold)
        {
            GameAssets.instance.gold -= itemPrice;
            goldText.GetComponent<TextMeshProUGUI>().text = GameAssets.instance.gold.ToString();
            return true;
        }
        return false;
    }
    private void LimitReached(string type)
    {
        GameObject obj = transform.Find(type).Find("Price").gameObject;
        obj.GetComponent<TextMeshProUGUI>().text = " MAX";
        obj.GetComponent<TextMeshProUGUI>().color = Color.green;
        GameObject objPic = transform.Find(type).Find("Gold").gameObject;
        objPic.SetActive(false);
    }

    private void GoldLimitReached(string type)
    {
        GameObject obj = transform.Find(type).Find("Price").gameObject;
        obj.GetComponent<TextMeshProUGUI>().text = " X";
        obj.GetComponent<TextMeshProUGUI>().color = Color.red;
        obj.GetComponent<TextMeshProUGUI>().fontSize = 45;
        GameObject objPic = transform.Find(type).Find("Gold").gameObject;
        objPic.SetActive(false);
    }

}
