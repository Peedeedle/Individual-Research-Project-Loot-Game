///\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
///     File:            Enemy_Boss.cs
///     Author:          Jack Peedle
///     Date Created:    16/01/2021
///     Brief:
///\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy_Boss : MonoBehaviour
{
    //Reference to money manager
    public static MoneyManager moneyManager;

    //Variables
    // Public integers for the enemies max health and current health
    public float StartHealth = 300;
    private float Health;

    // Healthbar
    [Header("Unity Stuff")]
    public Image healthBar;

    // Health increment per wave
    public float HealthIncrement = 30f;

    // Loot array
    public Enemy_BossDrops[] LootDrops;

    // Public transform target = player
    public Transform Target;

    // Reference to navmesh agent
    NavMeshAgent agent;

    

    // Start is called before the first frame update
    void Start()
    {
        // set health to start health
        Health = StartHealth;

        // Get nev mesh component and set target and restrict rotation
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        agent.destination = Target.position;

        // Find player gameobject
        GameObject.FindGameObjectWithTag("Player");

        // Get money manager component
        GameObject m = GameObject.FindGameObjectWithTag("MoneyMan");
        moneyManager = m.GetComponent<MoneyManager>();

    }

    // Update is called once per frame
    void Update()
    {
        // Set target destination to player
        agent.SetDestination(Target.position);
        Target = GameObject.FindGameObjectWithTag("Player").transform;
        
    }

    // Kill Enemy
    public void Die()
    {
        // Debug message, destroy the enemy and drop a randomized loot item
        print("Enemy " + this.gameObject.name + "has died!");
        Destroy(this.gameObject);
        DropRandomItems3();
    }

    // Take damage 
    public void TakeDamage(float amount)
    {
        // health - damage amount
        Health -= amount;

        // fill the health bar with current health
        healthBar.fillAmount = Health / StartHealth;

        // if health is less than or equal to 0
        if (Health <= 0)
        {
            // kill enemy and add medium money
            Die();
            moneyManager.MoneyAddHigh();
        }

    }

    // increase enemy health
    public void IncreaseEnemyHealth3()
    {
        // every wave increase enemy health by personal increment
        StartHealth += HealthIncrement;
        Debug.Log("Enemy Health Increased");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // If bullet collides with enemy
        if (collision.gameObject.CompareTag("PistolBullet"))
        {

            // Destroy the bullet
            Destroy(collision.gameObject);

            // Take damage
            TakeDamage(25f);
        }

        // If bullet collides with enemy
        if (collision.gameObject.CompareTag("SMGBullet"))
        {

            // Destroy the bullet
            Destroy(collision.gameObject);

            // Take damage
            TakeDamage(35f);
        }

        // If bullet collides with enemy
        if (collision.gameObject.CompareTag("M4Bullet"))
        {

            // Destroy the bullet
            Destroy(collision.gameObject);

            // Take damage
            TakeDamage(50f);
        }

        // If bullet collides with enemy
        if (collision.gameObject.CompareTag("AKBullet"))
        {

            // Destroy the bullet
            Destroy(collision.gameObject);

            // Take damage
            TakeDamage(65f);
        }

        // If bullet collides with enemy
        if (collision.gameObject.CompareTag("P90Bullet"))
        {
            // Destroy the bullet
            Destroy(collision.gameObject);

            // Take damage
            TakeDamage(80f);
        }
        


    }

    // drop loot
    void DropRandomItems3()
    {
        // random number between 0-1,000
        int i = Random.Range(0, 1000);
        for (int j = 0; j < LootDrops.Length; j++)
        {
            // If it is between the minimum and maximum range with i = number
            if (i >= LootDrops[j].minProbabilityRange && i <= LootDrops[j].maxProbabilityRange)
            {
                // Spawn loot at the enemies position
                Instantiate(LootDrops[j].spawnObject, transform.position, transform.rotation);
                break;
            }
        }

    }

}

// Class for probability
[System.Serializable]
public class Enemy_BossDrops
{
    // Loot object
    public GameObject spawnObject;

    // Min and max probability
    public int minProbabilityRange = 0;
    public int maxProbabilityRange = 0;

}