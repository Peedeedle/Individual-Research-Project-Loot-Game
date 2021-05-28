///\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
///     File:            MoneyManager.cs
///     Author:          Jack Peedle
///     Date Created:    20/12/2020
///     Brief:
///\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour
{
    // References to buyable weapons, buyable mystery box and gun variables
    public BuyableWhiteWeaponAndAmmo buyableWhiteWeaponAndAmmo;
    public BuyableGreenWeaponAndAmmo buyableGreenWeaponAndAmmo;
    public BuyableBlueWeaponAndAmmo buyableBlueWeaponAndAmmo;
    public BuyablePinkWeaponAndAmmo buyablePinkWeaponAndAmmo;
    public BuyableMysteryBox buyableMysteryBox;
    public GunVariables gunVariables;

    // drop point for player
    public GameObject PlayerDropPoint;

    // white and green loot
    public GameObject WhiteLoot;
    public GameObject GreenLoot;
    public GameObject BlueLoot;
    public GameObject PinkLoot;

    // current money and current money text
    public int currentMoney;
    public Text currentMoneyText;
    
    // White gun and ammo cost text
    public Text WhiteGunCost;
    public Text WhiteAmmoCost;

    // White gun and ammo cost
    public int WhiteGunCost1;
    public int WhiteAmmoCost1;



    // Green gun and ammo cost text
    public Text GreenGunCost;
    public Text GreenAmmoCost;

    // Green gun and ammo cosrt
    public int GreenGunCost1;
    public int GreenAmmoCost1;



    // Green gun and ammo cost text
    public Text BlueGunCost;
    public Text BlueAmmoCost;

    // Green gun and ammo cosrt
    public int BlueGunCost1;
    public int BlueAmmoCost1;



    // Green gun and ammo cost text
    public Text PinkGunCost;
    public Text PinkAmmoCost;

    // Green gun and ammo cosrt
    public int PinkGunCost1;
    public int PinkAmmoCost1;



    // Mystery box cost text and cost
    public Text MysteryBoxCost;
    public int MysteryBoxCost1;

    

    // Start is called before the first frame update
    void Start()
    {
        // Player starts with white gun so ammo is only visible
        WhiteGunCost.gameObject.SetActive(false);
        WhiteAmmoCost.gameObject.SetActive(true);


        // Green gun text is visible and not ammo
        GreenGunCost.gameObject.SetActive(true);
        GreenAmmoCost.gameObject.SetActive(false);


        // Green gun text is visible and not ammo
        BlueGunCost.gameObject.SetActive(true);
        BlueAmmoCost.gameObject.SetActive(false);


        // Green gun text is visible and not ammo
        PinkGunCost.gameObject.SetActive(true);
        PinkAmmoCost.gameObject.SetActive(false);


        // Set mystery box cost to active
        MysteryBoxCost.gameObject.SetActive(true);


        // Set current money and costs for wall buys
        currentMoney = 400;

        WhiteGunCost1 = 200;
        WhiteAmmoCost1 = 50;

        GreenGunCost1 = 800;
        GreenAmmoCost1 = 200;

        BlueGunCost1 = 2000;
        BlueAmmoCost1 = 500;

        PinkGunCost1 = 3000;
        PinkAmmoCost1 = 750;

        MysteryBoxCost1 = 2000;
    }

    // Update is called once per frame
    void Update()
    {
        // Set money text to current money
        currentMoneyText.text = "£" + currentMoney;
    }

    // Add money after enemy is killed
    public void MoneyAddBasic()
    {
        // Add £20
        currentMoney += 20;
    }

    // Add money after enemy is killed
    public void MoneyAddMedium()
    {
        // Add £10
        currentMoney += 10;
    }

    // Add money after enemy is killed
    public void MoneyAddHigh()
    {
        // Add £50
        currentMoney += 50;
    }



    // If white gun is true
    public void WhiteIsTrue()
    {
        // Show purchasable white gun ammo
        WhiteGunCost.gameObject.SetActive(false);
        WhiteAmmoCost.gameObject.SetActive(true);

        // set white gun to true
        buyableWhiteWeaponAndAmmo.IsWhiteTrueMoney = true;
        buyableWhiteWeaponAndAmmo.IsWhiteFalseMoney = false;
    }

    // If white gun is not true
    public void WhiteIsNotTrue()
    {
        // Show purchasable white gun
        WhiteGunCost.gameObject.SetActive(true);
        WhiteAmmoCost.gameObject.SetActive(false);

        // set white gun to false
        buyableWhiteWeaponAndAmmo.IsWhiteTrueMoney = false;
        buyableWhiteWeaponAndAmmo.IsWhiteFalseMoney = true;

    }



    // If green gun is true
    public void GreenIsTrue()
    {
        // Show purchasable green gun ammo
        GreenGunCost.gameObject.SetActive(false);
        GreenAmmoCost.gameObject.SetActive(true);

        // set green gun to true
        buyableGreenWeaponAndAmmo.IsGreenTrueMoney = true;
        buyableGreenWeaponAndAmmo.IsGreenFalseMoney = false;
    }

    // If green gun is not true
    public void GreenIsNotTrue()
    {
        // Show purchasable green gun
        GreenGunCost.gameObject.SetActive(true);
        GreenAmmoCost.gameObject.SetActive(false);

        // set green gun to false
        buyableGreenWeaponAndAmmo.IsGreenTrueMoney = false;
        buyableGreenWeaponAndAmmo.IsGreenFalseMoney = true;

    }


    // If Blue gun is true
    public void BlueIsTrue()
    {
        // Show purchasable blue gun ammo
        BlueGunCost.gameObject.SetActive(false);
        BlueAmmoCost.gameObject.SetActive(true);

        // set blue gun to true
        buyableBlueWeaponAndAmmo.IsBlueTrueMoney = true;
        buyableBlueWeaponAndAmmo.IsBlueFalseMoney = false;
    }

    // If Blue gun is not true
    public void BlueIsNotTrue()
    {
        // Show purchasable blue gun
        BlueGunCost.gameObject.SetActive(true);
        BlueAmmoCost.gameObject.SetActive(false);

        // set blue gun to false
        buyableBlueWeaponAndAmmo.IsBlueTrueMoney = false;
        buyableBlueWeaponAndAmmo.IsBlueFalseMoney = true;

    }



    // If pink gun is true
    public void PinkIsTrue()
    {
        // Show purchasable Pink gun ammo
        PinkGunCost.gameObject.SetActive(false);
        PinkAmmoCost.gameObject.SetActive(true);

        // set Pink gun to true
        buyablePinkWeaponAndAmmo.IsPinkTrueMoney = true;
        buyablePinkWeaponAndAmmo.IsPinkFalseMoney = false;
    }

    // If Pink gun is not true
    public void PinkIsNotTrue()
    {
        // Show purchasable Pink gun
        PinkGunCost.gameObject.SetActive(true);
        PinkAmmoCost.gameObject.SetActive(false);

        // set Pink gun to false
        buyablePinkWeaponAndAmmo.IsPinkTrueMoney = false;
        buyablePinkWeaponAndAmmo.IsPinkFalseMoney = true;

    }











    // buy white gun
    public void BuyWhiteGun()
    {
        // If the player has enough money, buy a gun for the player
        if (currentMoney >= WhiteGunCost1)
        {
            // take cost of white gun away from current money, instantiate gun
            currentMoney -= WhiteGunCost1;
            Instantiate(WhiteLoot, PlayerDropPoint.transform.position, PlayerDropPoint.transform.rotation);
        }

    }

    // buy white ammo
    public void BuyWhiteAmmo()
    {
        // If current and max pistol ammo is max
        if (gunVariables.PistolmaxAmmo >= gunVariables.PistolTotalMaxAmmo)
        {
            // return
            return;
        }
        

        // If the player has enough money, buy ammo for the player
        if (currentMoney >= WhiteAmmoCost1)
        {
            // take cost of white ammo away from current money, give max ammo
            currentMoney -= WhiteAmmoCost1;
            gunVariables.PistolcurrentAmmo = gunVariables.PistolClipSize;
            gunVariables.PistolmaxAmmo = gunVariables.PistolTotalMaxAmmo;

        }
    }




    public void BuyGreenGun()
    {
        // If the player has enough money, buy a gun for the player
        if (currentMoney >= GreenGunCost1)
        {
            // take cost of green gun away from current money, instantiate gun
            currentMoney -= GreenGunCost1;
            Instantiate(GreenLoot, PlayerDropPoint.transform.position, PlayerDropPoint.transform.rotation);
        }

    }

    // buy green ammo
    public void BuyGreenAmmo()
    {
        // If current and max SMG ammo is max
        if (gunVariables.SMGmaxAmmo >= gunVariables.SMGTotalMaxAmmo)
        {
            // Return
            return;
        }


        // If the player has enough money, buy ammo for the player
        if (currentMoney >= GreenAmmoCost1)
        {
            // take cost of green ammo away from current money, give max ammo
            currentMoney -= GreenAmmoCost1;
            gunVariables.SMGcurrentAmmo = gunVariables.SMGClipSize;
            gunVariables.SMGmaxAmmo = gunVariables.SMGTotalMaxAmmo;

        }
    }




    public void BuyBlueGun()
    {
        // If the player has enough money, buy a gun for the player
        if (currentMoney >= BlueGunCost1)
        {
            // take cost of blue gun away from current money, instantiate gun
            currentMoney -= BlueGunCost1;
            Instantiate(BlueLoot, PlayerDropPoint.transform.position, PlayerDropPoint.transform.rotation);
        }

    }

    // buy blue ammo
    public void BuyBlueAmmo()
    {
        // If current and max M4 ammo is max
        if (gunVariables.M4maxAmmo >= gunVariables.M4TotalMaxAmmo)
        {
            // Return
            return;
        }


        // If the player has enough money, buy ammo for the player
        if (currentMoney >= BlueAmmoCost1)
        {
            // take cost of blue ammo away from current money, give max ammo
            currentMoney -= BlueAmmoCost1;
            gunVariables.M4currentAmmo = gunVariables.M4ClipSize;
            gunVariables.M4maxAmmo = gunVariables.M4TotalMaxAmmo;

        }
    }



    public void BuyPinkGun()
    {
        // If the player has enough money, buy a gun for the player
        if (currentMoney >= PinkGunCost1)
        {
            // take cost of Pink gun away from current money, instantiate gun
            currentMoney -= PinkGunCost1;
            Instantiate(PinkLoot, PlayerDropPoint.transform.position, PlayerDropPoint.transform.rotation);
        }

    }

    // buy Pink ammo
    public void BuyPinkAmmo()
    {
        // If current and max AK ammo is max
        if (gunVariables.AKmaxAmmo >= gunVariables.AKTotalMaxAmmo)
        {
            // Return
            return;
        }


        // If the player has enough money, buy ammo for the player
        if (currentMoney >= PinkAmmoCost1)
        {
            // take cost of Pink ammo away from current money, give max ammo
            currentMoney -= PinkAmmoCost1;
            gunVariables.AKcurrentAmmo = gunVariables.AKClipSize;
            gunVariables.AKmaxAmmo = gunVariables.AKTotalMaxAmmo;

        }
    }



    

    // Buy mystery box
    public void BuyMysteryBox()
    {
        // If player has enough money for the mystery box
        if (currentMoney >= MysteryBoxCost1)
        {
            // takeaway money and drop mystery box loot
            currentMoney -= MysteryBoxCost1;
            buyableMysteryBox.DropMysteryBoxItem();
        }
        else
        {
            // else do nothing
            return;
        }
    }


}
