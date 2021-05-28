///\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
///     File:            BuyablePinkWeaponAndAmmo.cs
///     Author:          Jack Peedle
///     Date Created:    25/01/2021
///     Brief:
///\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyablePinkWeaponAndAmmo : MonoBehaviour
{
    // Reference to moneymanager
    public MoneyManager moneyManager;

    // Bools for Pink gun and ammo is true or false
    public bool IsPinkTrueMoney = false;
    public bool IsPinkFalseMoney = false;
    

    public void Start()
    {
        // Set white gun to true
        IsPinkTrueMoney = true;
        IsPinkFalseMoney = false;
        
    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        // If collides with player
        if (collision.gameObject.tag == "Player")
        {
            // if white gun is true
            if (IsPinkTrueMoney)
            {
                // Buy ammo
                moneyManager.BuyPinkAmmo();
            }

            // if white gun is false
            if (IsPinkFalseMoney)
            {
                // Buy gun
                moneyManager.BuyPinkGun();
            }
            

        }

    }
    
}
