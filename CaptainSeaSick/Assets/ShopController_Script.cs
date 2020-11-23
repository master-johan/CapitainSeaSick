using System.Collections;
using System.Collections.Generic;
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
        cannonText.GetComponent<Text>().text = "Cannons: " + GameAssets.instance.numberOfCannons;
        goldText.GetComponent<Text>().text = "Gold: " + GameAssets.instance.gold;
        cannonBallDamageText.GetComponent<Text>().text = "Cannonball damage: " + GameAssets.instance.cannonballsDamage;
        swordsText.GetComponent<Text>().text = "Swords: " + GameAssets.instance.numberOfSwords;
        shipHealthpointsText.GetComponent<Text>().text = "Ship maxhealth: " + GameAssets.instance.ShipMaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void BuyCannon()
    {
        if (CheckGold(GameAssets.instance.cannonPrice))
        {
            GameAssets.instance.numberOfCannons++;

            cannonText.GetComponent<Text>().text = "Cannons: " + GameAssets.instance.numberOfCannons;
        }
    }

    public void BuySword()
    {
        if (CheckGold(GameAssets.instance.swordPrice))
        {
            GameAssets.instance.numberOfSwords++;

            swordsText.GetComponent<Text>().text = "Swords: " + GameAssets.instance.numberOfSwords;
        }
    }

    public void BuyHealth()
    {
        if (CheckGold(GameAssets.instance.shipMaxHealthPrice))
        {
            GameAssets.instance.ShipMaxHealth += 50;

            shipHealthpointsText.GetComponent<Text>().text = "Ship maxhealth: " + GameAssets.instance.ShipMaxHealth;
        }
    }

    public void CannonballDamage()
    {
        if (CheckGold(GameAssets.instance.cannonballDamagePrice))
        {
            GameAssets.instance.cannonballsDamage += 5;

            cannonBallDamageText.GetComponent<Text>().text = "Cannonball damage: " + GameAssets.instance.cannonballsDamage;
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
            goldText.GetComponent<Text>().text = "Gold: " + GameAssets.instance.gold;
            return true;
        }
        return false;
    }
}
