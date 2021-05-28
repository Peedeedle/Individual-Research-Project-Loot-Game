///\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
///     File:            BuyableWhiteWeaponAndAmmo.cs
///     Author:          Jack Peedle
///     Date Created:    21/01/2021
///     Brief:
///\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyableWhiteWeaponAndAmmo : MonoBehaviour
{
    // Reference to moneymanager
    public MoneyManager moneyManager;

    // Bools for White gun and ammo is true or false
    public bool IsWhiteTrueMoney = false;
    public bool IsWhiteFalseMoney = false;
    

    public void Start()
    {
        // Set white gun to true
        IsWhiteTrueMoney = true;
        IsWhiteFalseMoney = false;
        
    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        // If collides with player
        if (collision.gameObject.tag == "Player")
        {
            // if white gun is true
            if (IsWhiteTrueMoney)
            {
                // Buy ammo
                moneyManager.BuyWhiteAmmo();
            }

            // if white gun is false
            if (IsWhiteFalseMoney)
            {
                // Buy gun
                moneyManager.BuyWhiteGun();
            }
            

        }

    }
    
}
