///\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
///     File:            BuyableGreenWeaponAndAmmo.cs
///     Author:          Jack Peedle
///     Date Created:    21/01/2021
///     Brief:
///\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyableGreenWeaponAndAmmo : MonoBehaviour
{
    // Reference to moneymanager
    public MoneyManager moneyManager;
    
    // Bools for green gun and ammo is true or false
    public bool IsGreenTrueMoney = false;
    public bool IsGreenFalseMoney = true;
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        // If collides with player
        if (collision.gameObject.tag == "Player")
        {
            // And if green gun is true
            if (IsGreenTrueMoney)
            {
                // Buy ammo
                moneyManager.BuyGreenAmmo();
            }

            // If green gun is not true
            if (IsGreenFalseMoney)
            {
                // Buy gun
                moneyManager.BuyGreenGun();
            }

        }

    }
    
}
