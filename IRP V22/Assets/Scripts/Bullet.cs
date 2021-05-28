///\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
///     File:            Bullet.cs
///     Author:          Jack Peedle
///     Date Created:    08/10/2020
///     Brief:
///\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    void start()
    {
        // Do not collide with Loot
        Physics2D.IgnoreLayerCollision(8, 10, true);
    }

    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // If bullet collides with the Wall
        if (collision.gameObject.CompareTag("Wall"))
        {
            // Destroy the bullet
            Destroy(this.gameObject);
        }
        
    }



}

    

