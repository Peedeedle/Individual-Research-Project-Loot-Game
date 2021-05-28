///\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
///     File:            BuyableBlueWeaponAndAmmo.cs
///     Author:          Jack Peedle
///     Date Created:    21/01/2021
///     Brief:
///\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyableBlueWeaponAndAmmo : MonoBehaviour
{
    // Reference to moneymanager
    public MoneyManager moneyManager;

    // Bools for White gun and ammo is true or false
    public bool IsBlueTrueMoney = false;
    public bool IsBlueFalseMoney = false;
    

    public void Start()
    {
        // Set white gun to true
        IsBlueTrueMoney = true;
        IsBlueFalseMoney = false;
        
    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        // If collides with player
        if (collision.gameObject.tag == "Player")
        {
            // if white gun is true
            if (IsBlueTrueMoney)
            {
                // Buy ammo
                moneyManager.BuyBlueAmmo();
            }

            // if white gun is false
            if (IsBlueFalseMoney)
            {
                // Buy gun
                moneyManager.BuyBlueGun();
            }
            

        }

    }
    
}
