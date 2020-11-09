using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopController_Script : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void BuyCannon()
    {
        GameAssets.instance.numberOfCannons++;
    }

    public void BuySword()
    {
        GameAssets.instance.numberOfSwords++;
    }

    public void BuyHealth()
    {
        GameAssets.instance.ShipMaxHealth += 50;
    }

    public void CannonballDamage()
    {
        GameAssets.instance.cannonballsDamage += 5;
    }

    public void NextLevel()
    {
        GameObject.Find("LevelLoader").GetComponent<LevelLoader>().LoadNextLevel();
    }
}
