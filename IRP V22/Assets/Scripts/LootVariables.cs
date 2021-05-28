///\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
///     File:            LootVariables.cs
///     Author:          Jack Peedle
///     Date Created:    25/10/2020
///     Brief:
///\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootVariables : MonoBehaviour
{
    // On Start
    private void Start()
    {
        // Ignore bullet and enemy layer
        Physics2D.IgnoreLayerCollision(9, 10, true);

        // Start loot timer
        StartCoroutine(LootTimer());
    }

    // Loot timer
    IEnumerator LootTimer()
    {
        // Wait for 30 seconds and then destroy the loot
        yield return new WaitForSeconds(30);
        Destroy(gameObject);
        
    }

}
