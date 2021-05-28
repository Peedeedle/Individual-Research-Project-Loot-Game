///\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
///     File:            BuyableMysteryBox.cs
///     Author:          Jack Peedle
///     Date Created:    21/01/2021
///     Brief:
///\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyableMysteryBox : MonoBehaviour
{
    // Reference to moneymanager
    public MoneyManager moneyManager;

    // Loot drop array for mystery box
    public BuyableMysteryBoxLoot[] LootDrops;

    // gameobject for where the loot drops from the box
    public GameObject MysteryboxDrop;

    // when collides with player
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // buy a msytery box
            moneyManager.BuyMysteryBox();
        }
            

    }

    // whilst in mystery box area
    public void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // do nothing until the player leaves
            Debug.Log("Stayedinthebox");
            return;
            
        }
    }

    // drop mystery box loot
    public void DropMysteryBoxItem()
    {
        // drop loot
        DropMysteryItems();
    }

    // drop loot
    public void DropMysteryItems()
    {
        // random number between 0-1,000
        int i = Random.Range(0, 1000);
        for (int j = 0; j < LootDrops.Length; j++)
        {
            // If it is between the minimum and maximum range with i = number
            if (i >= LootDrops[j].minProbabilityRange && i <= LootDrops[j].maxProbabilityRange)
            {
                // Spawn loot at the mysterybox position and rotation
                Instantiate(LootDrops[j].spawnObject, MysteryboxDrop.transform.position, MysteryboxDrop.transform.rotation);
                break;
            }
        }
    }

    // Class for probability
    [System.Serializable]
    public class BuyableMysteryBoxLoot
    {
        // Loot object
        public GameObject spawnObject;

        // Min and max probability
        public int minProbabilityRange = 0;
        public int maxProbabilityRange = 0;

    }

}
