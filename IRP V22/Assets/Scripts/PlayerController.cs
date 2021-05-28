///\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
///     File:            PlayerController.cs
///     Author:          Jack Peedle
///     Date Created:    04/10/2020
///     Brief:
///\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // reference to gun variables
    public GunVariables gunVariables;

    // Start health and health
    public float StartHealth = 100;
    private float Health;

    // Healthbar
    [Header("Unity Stuff")]
    public Image healthBar;

    // Add health float
    public float addHealthPowerup = 40;

    // How often damage is done to the player
    public float damageTime = 0.25f;
    public float currentDamageTime;

    // Shown image of which gun is currently active
    public Image GunColouredImage;

    // Player controller
    public static PlayerController playercontroller;
    
    // Bool is player sprinting
    public bool isSprinting;

    // Stamina bar
    public Slider StaminaBar;

    // Stamina loss
    public float StaminaLoss;

    // Max stamina and current stamina
    private float maxStamina = 100;
    private float currentStamina;

    // Wait for seconds, regen cororutine 
    private WaitForSeconds regenTick = new WaitForSeconds(0.1f);
    private Coroutine Regen;

    // Movespeed
    public float moveSpeed = 2.5f;

    // Rigidbody reference
    public Rigidbody2D rb;

    // Public camera refernce
    public Camera cam;

    // Movement
    Vector2 movement;

    // Mouse position
    Vector2 mousePos;

    // On start
    void Start()
    {
        // set sprinting to false
        isSprinting = false;
        
        // Health = start health
        Health = StartHealth;

        // current stamina = max stamina
        currentStamina = maxStamina;
        StaminaBar.maxValue = maxStamina;
        StaminaBar.value = maxStamina;

        // get Gun variable script component
        GameObject g = GameObject.FindGameObjectWithTag("GunVar");
        gunVariables = g.GetComponent<GunVariables>();

    }

    // Die
    public void Died()
    {
        // Load main menu
        SceneManager.LoadScene("MainMenu");
    }

    // Trigger and input for movement
    void Update()
    {
        // Movement Horizontal and Vertical
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Convert Mouse position to world co-ordinates from pixel 
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);




        // If current stamina - stamina loss >= 0 and left shift is being held down
        if (currentStamina - StaminaLoss >= 0 && (Input.GetKey(KeyCode.LeftShift)))
        {
            // Set Sprinting to true
            isSprinting = true;


            // Drain stamina bar depending on time.deltatime
            currentStamina -= StaminaLoss * Time.deltaTime;
            StaminaBar.value = currentStamina;

            // if regen is not equal to null stop the regen coroutine
            if (Regen != null)
                StopCoroutine(Regen);
            // reference to regen coroutine
            Regen = StartCoroutine(RegenStamina());
        }
        else
        {   // else set sprinting to false
            isSprinting = false;

        }

        // If sprinting is true set speed to double normal speed (6)
        if (isSprinting)
        {
            moveSpeed = 4f;
        }

        // If sprinting is not true set speed to normal speed (4)
        if (!isSprinting)
        {
            moveSpeed = 2.5f;
        }

        // If health is less than or = 0
        if (Health <= 0)
        {
            // Kill player
            Died();

        }

        // If health is more than or = 100
        if (Health >= 100)
        {
            // set health to 100
            Health = 100;
        }

    }


    // private regen IEnumerator
    private IEnumerator RegenStamina()
    {
        // Wait two seconds before starting the regen
        yield return new WaitForSeconds(2);

        // While stamina is not max regenerate stamina
        while (currentStamina < maxStamina)
        {
            // add max stamina divided by 100 to current stamina (regen)
            currentStamina += maxStamina / 100;
            StaminaBar.value = currentStamina;
            yield return regenTick;
        }
        // Set Regen to Null
        Regen = null;
    }


    // Movement in fixed update
    void FixedUpdate()
    {
        // Move Rigidbody
        rb.MovePosition(rb.position + movement * moveSpeed * Time.deltaTime);

        // Look Direction
        Vector2 lookDir = mousePos - rb.position;

        // Math function returns angle between X axis to Y, convert radians to degrees
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;

        // Apply to player RB
        rb.rotation = angle;
    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        // If collides with enemy
        if (collision.gameObject.tag == "Enemy")
        {
            // if current damage time is more than damage time
            currentDamageTime += Time.deltaTime;
            if (currentDamageTime > damageTime)
            {
                // take 20 health away from player
                Health -= 20f;
                healthBar.fillAmount = Health / StartHealth;

                // Set current damage time to 0
                currentDamageTime = 0f;
            }

        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        
        // if player collides with white loot
        if (collision.gameObject.tag == "WhiteLoot")
        {
            // Set white gun to true and other guns to false
            Debug.Log("CollidedWithWhite");
            GunColouredImage.color = Color.white;
            Destroy(collision.gameObject);
            gunVariables.IsWhitePistolTrue = true;
            gunVariables.IsGreenSMGTrue = false;
            gunVariables.IsBlueM4True = false;
            gunVariables.IsPinkAKTrue = false;
            gunVariables.IsRedP90True = false;

            // If player has white gun and collides with white loot
            if (gunVariables.IsWhitePistolTrue && collision.gameObject.tag == "WhiteLoot")
            {
                // Give current gun + clip size
                gunVariables.PistolmaxAmmo += 6;

                // If guns max ammo is more than allowed max ammo, set max ammo to max ammo
                if (gunVariables.PistolmaxAmmo > 60)
                {
                    gunVariables.PistolmaxAmmo = 60;
                }


            }

        }

        // if player collides with green loot
        if (collision.gameObject.tag == "GreenLoot")
        {
            // Set green gun to true and other guns to false
            Debug.Log("CollidedWithGreen");
            GunColouredImage.color = Color.green;
            Destroy(collision.gameObject);
            gunVariables.IsWhitePistolTrue = false;
            gunVariables.IsGreenSMGTrue = true;
            gunVariables.IsBlueM4True = false;
            gunVariables.IsPinkAKTrue = false;
            gunVariables.IsRedP90True = false;

            // If player has green gun and collides with green loot
            if (gunVariables.IsGreenSMGTrue && collision.gameObject.tag == "GreenLoot")
            {
                // Give current gun + clip size
                gunVariables.SMGmaxAmmo += 15;

                // If guns max ammo is more than allowed max ammo, set max ammo to max ammo
                if (gunVariables.SMGmaxAmmo > 150)
                {
                    gunVariables.SMGmaxAmmo = 150;
                }


            }

        }

        // if player collides with blue loot
        if (collision.gameObject.tag == "BlueLoot")
        {
            // Set blue gun to true and other guns to false
            Debug.Log("CollidedWithBlue");
            GunColouredImage.color = Color.blue;
            Destroy(collision.gameObject);
            gunVariables.IsWhitePistolTrue = false;
            gunVariables.IsGreenSMGTrue = false;
            gunVariables.IsBlueM4True = true;
            gunVariables.IsPinkAKTrue = false;
            gunVariables.IsRedP90True = false;

            // If player has blue gun and collides with blue loot
            if (gunVariables.IsBlueM4True && collision.gameObject.tag == "BlueLoot")
            {
                // Give current gun + clip size
                gunVariables.M4maxAmmo += 30;

                // If guns max ammo is more than allowed max ammo, set max ammo to max ammo
                if (gunVariables.M4maxAmmo > 300)
                {
                    gunVariables.M4maxAmmo = 300;
                }


            }



        }

        // if player collides with pink loot
        if (collision.gameObject.tag == "PinkLoot")
        {
            // Set pink gun to true and other guns to false
            Debug.Log("CollidedWithPink");
            GunColouredImage.color = Color.magenta;
            Destroy(collision.gameObject);
            gunVariables.IsWhitePistolTrue = false;
            gunVariables.IsGreenSMGTrue = false;
            gunVariables.IsBlueM4True = false;
            gunVariables.IsPinkAKTrue = true;
            gunVariables.IsRedP90True = false;

            // If player has pink gun and collides with pink loot
            if (gunVariables.IsPinkAKTrue && collision.gameObject.tag == "PinkLoot")
            {
                // Give current gun + clip size
                gunVariables.AKmaxAmmo += 40;

                // If guns max ammo is more than allowed max ammo, set max ammo to max ammo
                if (gunVariables.AKmaxAmmo > 440)
                {
                    gunVariables.AKmaxAmmo = 440;
                }


            }

        }

        // if player collides with red loot
        if (collision.gameObject.tag == "RedLoot")
        {
            // Set red gun to true and other guns to false
            Debug.Log("CollidedWithRed");
            GunColouredImage.color = Color.red;
            Destroy(collision.gameObject);
            gunVariables.IsWhitePistolTrue = false;
            gunVariables.IsGreenSMGTrue = false;
            gunVariables.IsBlueM4True = false;
            gunVariables.IsPinkAKTrue = false;
            gunVariables.IsRedP90True = true;

            // If player has red gun and collides with red loot
            if (gunVariables.IsRedP90True && collision.gameObject.tag == "RedLoot")
            {
                // Give current gun + clip size
                gunVariables.P90maxAmmo += 60;

                // If guns max ammo is more than allowed max ammo, set max ammo to max ammo
                if (gunVariables.P90maxAmmo > 660)
                {
                    gunVariables.P90maxAmmo = 660;
                }


            }

        }

        // if player collides with ammo loot
        if (collision.gameObject.tag == "AmmoPowerup")
        {
            // Set all guns ammo to max
            Debug.Log("CollidedWithAmmo");
            Destroy(collision.gameObject);
            gunVariables.PistolmaxAmmo = gunVariables.PistolTotalMaxAmmo;
            gunVariables.PistolcurrentAmmo = gunVariables.PistolClipSize;
            gunVariables.hasPistolGotAmmo = true;

            gunVariables.SMGmaxAmmo = gunVariables.SMGTotalMaxAmmo;
            gunVariables.SMGcurrentAmmo = gunVariables.SMGClipSize;
            gunVariables.hasSMGGotAmmo = true;

            gunVariables.M4maxAmmo = gunVariables.M4TotalMaxAmmo;
            gunVariables.M4currentAmmo = gunVariables.M4ClipSize;
            gunVariables.hasM4GotAmmo = true;

            gunVariables.AKmaxAmmo = gunVariables.AKTotalMaxAmmo;
            gunVariables.AKcurrentAmmo = gunVariables.AKClipSize;
            gunVariables.hasAKGotAmmo = true;

            gunVariables.P90maxAmmo = gunVariables.P90TotalMaxAmmo;
            gunVariables.P90currentAmmo = gunVariables.P90ClipSize;
            gunVariables.hasP90GotAmmo = true;
        }

        // if player collides with health loot
        if (collision.gameObject.tag == "HealthPowerup")
        {
            // Add health to players current health
            Debug.Log("CollidedWithHealth");

            Health += 40f;
            healthBar.fillAmount = Health / StartHealth;

            // destroy health object
            Destroy(collision.gameObject);
            
        }
        
        
    }

}
