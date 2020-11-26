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
        cannonText.GetComponent<TextMeshProUGUI>().text = "Cannons: " + GameAssets.instance.numberOfCannons;
        goldText.GetComponent<TextMeshProUGUI>().text = "Gold: " + GameAssets.instance.gold;
        cannonBallDamageText.GetComponent<TextMeshProUGUI>().text = "Cannonball damage: " + GameAssets.instance.cannonballsDamage;
        swordsText.GetComponent<TextMeshProUGUI>().text = "Swords: " + GameAssets.instance.numberOfSwords;
        shipHealthpointsText.GetComponent<TextMeshProUGUI>().text = "Ship maxhealth: " + GameAssets.instance.ShipMaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void BuyCannon()
    {
        if (GameAssets.instance.numberOfCannons <= 4)
        {
            if (CheckGold(GameAssets.instance.cannonPrice))
            {
                GameAssets.instance.numberOfCannons++;

                cannonText.GetComponent<TextMeshProUGUI>().text = "Cannons: " + GameAssets.instance.numberOfCannons;
            }
        }
        else
        {
            LimitReached("Cannon");
        }
    }

    public void BuySword()
    {
        if (GameAssets.instance.numberOfSwords <= 4)
        {
            if (CheckGold(GameAssets.instance.swordPrice))
            {
                GameAssets.instance.numberOfSwords++;

                swordsText.GetComponent<TextMeshProUGUI>().text = "Swords: " + GameAssets.instance.numberOfSwords;
            }
        }
        else
        {
            LimitReached("Sword");
        }
    }

    public void BuyHealth()
    {
        if (GameAssets.instance.ShipMaxHealth <= 500)
        {
            if (CheckGold(GameAssets.instance.shipMaxHealthPrice))
            {
                GameAssets.instance.ShipMaxHealth += 50;

                shipHealthpointsText.GetComponent<TextMeshProUGUI>().text = "Ship maxhealth: " + GameAssets.instance.ShipMaxHealth;
            }
        }
        else
        {
            LimitReached("Health");
        }
    }

    public void CannonballDamage()
    {
        if (GameAssets.instance.cannonballsDamage <= 20)
        {
            if (CheckGold(GameAssets.instance.cannonballDamagePrice))
            {
                GameAssets.instance.cannonballsDamage += 5;

                cannonBallDamageText.GetComponent<TextMeshProUGUI>().text = "Cannonball damage: " + GameAssets.instance.cannonballsDamage;
            }
        }
        else
        {
            LimitReached("Upgraded Cannonballs");
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
            goldText.GetComponent<TextMeshProUGUI>().text = "Gold: " + GameAssets.instance.gold;
            return true;
        }
        return false;
    }
    private void LimitReached(string type)
    {
        GameObject obj = transform.Find(type).Find("Price").gameObject;
        obj.GetComponent<TextMeshProUGUI>().text = "FULL";
        GameObject objPic = transform.Find(type).Find("Gold").gameObject;
        objPic.SetActive(false);
    }
}
