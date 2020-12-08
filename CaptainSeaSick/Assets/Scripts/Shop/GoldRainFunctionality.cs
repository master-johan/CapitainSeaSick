using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldRainFunctionality : MonoBehaviour
{

    public ParticleSystem particles;

    void Start()
    {
        particles.Stop();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayParticleEffectCannon()
    {
        if (GameAssets.instance.numberOfCannons < 4 && CheckGold(GameAssets.instance.cannonPrice))
        {

            particles.Play();

        }
        else
        {


        }
    }
    public void PlayParticleEffectCannonBall()
    {
        if (GameAssets.instance.cannonballsDamage < 20 && CheckGold(GameAssets.instance.cannonballDamagePrice))
        {

            particles.Play();

        }
        else
        {


        }
    }
    public void PlayParticleEffectHealth()
    {
        if (GameAssets.instance.ShipMaxHealth < 500 && CheckGold(GameAssets.instance.shipMaxHealthPrice))
        {

            particles.Play();

        }
        else
        {

        }
    }
    public void PlayParticleEffectSword()
    {
        if (GameAssets.instance.numberOfSwords < 3 && CheckGold(GameAssets.instance.swordPrice))
        {

            particles.Play();

        }
        else
        {

        }
    }

    private bool CheckGold(int itemPrice)
    {
        if (itemPrice <= GameAssets.instance.gold)
        {
            return true;
        }
        return false;
    }
}
