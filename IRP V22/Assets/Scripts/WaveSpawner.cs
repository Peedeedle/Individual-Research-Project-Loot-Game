///\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
///     File:            WaveSpawner.cs
///     Author:          Jack Peedle
///     Date Created:    01/01/2021
///     Brief:
///\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;
[System.Serializable]

public class Wave
{
    // variables and references for types of enemies + number of enemies, wave name and spawn interval
    public string waveName;
    public int numberOfEnemies;
    public GameObject[] typeOfEnemies;
    public float spawnInterval;
}

public class WaveSpawner : MonoBehaviour
{
    // Reference to all 3 enemies
    public Enemy_Basic enemy_Basic;
    public Enemy_Runner enemy_Runner;
    public Enemy_Boss enemy_Boss;

    // Wave array
    public Wave[] waves;

    // Spawn points transform
    public Transform[] spawnPoints;

    // Animator and wave name
    public Animator animator;
    public Text waveName;

    // Current wave and wave number
    private Wave currentWave;
    private int currentWaveNumber;

    // next spawn time
    private float nextSpawnTime;

    // bool for if enemies can and can not spawn
    private bool canSpawn = true;
    private bool canAnimate = false;

    // Update
    private void Update()
    {
        // current wave = waves.number
        currentWave = waves[currentWaveNumber];

        // spawn wave
        SpawnWave();

        // find objects with array and tag of enemies
        GameObject[] totalEnemies = GameObject.FindGameObjectsWithTag("Enemy");

        // If you have killed all the enemies
        if (totalEnemies.Length == 0)
        {
            // And you have do not have another wave to spawn
            if (currentWaveNumber + 1 != waves.Length)
            {
                // If there is another wave to spawn, add the wave number
                if (canAnimate)
                {
                    // increase wave by 1 on wave text
                    waveName.text = waves[currentWaveNumber + 1].waveName;
                    animator.SetTrigger("WaveComplete");
                    canAnimate = false;
                }
                
                
            }
            // Finish the game
            else
            {
                SceneManager.LoadScene("WinScene");
                Debug.Log("Game Finished");
            }


        }
        

    }
    
    // Spawn next wave
    void SpawnNextWave()
    {
        // Increase wave by 1
        currentWaveNumber++;
        canSpawn = true;

        // Increase enemy health per wave
        enemy_Basic.IncreaseEnemyHealth1();
        enemy_Runner.IncreaseEnemyHealth2();
        enemy_Boss.IncreaseEnemyHealth3();
    }
    
    // Spawn current wave
    void SpawnWave()
    {
        // if can spawn is true and next spawn time is less than time.time
        if (canSpawn && nextSpawnTime < Time.time)
        {
            //Random enemy = current enemies in random range, randomize enemy to spawn
            GameObject randomEnemy = currentWave.typeOfEnemies[Random.Range(0, currentWave.typeOfEnemies.Length)];

            // randomize spawn points for enemies
            Transform randomPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

            // Instantiate random enemy at a random spawn point
            Instantiate(randomEnemy, randomPoint.position, Quaternion.identity);

            // Current wave - number of enemies
            currentWave.numberOfEnemies--;

            // Set next spawn time
            nextSpawnTime = Time.time + currentWave.spawnInterval;

            // if there are no more enemies
            if (currentWave.numberOfEnemies == 0)
            {
                // set can spawn as false and animate wave complete
                canSpawn = false;
                canAnimate = true;
            }

        }


    }

}
