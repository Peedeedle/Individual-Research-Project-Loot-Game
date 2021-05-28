///\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
///     File:            GunVariables.cs
///     Author:          Jack Peedle
///     Date Created:    01/01/2021
///     Brief:
///\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunVariables : MonoBehaviour
{
    // reference to money manager
    public MoneyManager moneyManager;

    // Reload text
    public Text ReloadGunText;

    // current and reserve pistol ammo text
    public Text CurrentPistolAmmoText;
    public Text ReservePistolAmmoText;

    // current and reserve SMG ammo text
    public Text CurrentSMGAmmoText;
    public Text ReserveSMGAmmoText;

    // current and reserve M4 ammo text
    public Text CurrentM4AmmoText;
    public Text ReserveM4AmmoText;

    // current and reserve AK ammo text
    public Text CurrentAKAmmoText;
    public Text ReserveAKAmmoText;

    // current and reserve P90 ammo text
    public Text CurrentP90AmmoText;
    public Text ReserveP90AmmoText;

    // Bullet force/speed
    public float PistolbulletForce = 20f;

    //Transform for the fire point and reference to bullet prefab
    public Transform PistolFirePoint;
    public GameObject PistolBulletPrefab;

    // pistol float variables
    public float Pistoldamage = 25f;
    public float Pistolrange = 50f;
    public float PistolfireRate = 15f;
    public float PistolreloadTime = 1.5f;
    private float PistolnextTimeToFire = 1f;

    // pistol int variables
    public int PistolmaxAmmo = 60;
    public int PistolcurrentAmmo = 6;
    public int PistolClipSize = 6;
    public int PistolTotalMaxAmmo = 60;

    // pistol bools
    public bool hasPistolGotAmmo = true;
    private bool isPistolReloading = false;
    
    

    // Bullet force/speed
    public float SMGbulletForce = 30f;

    //Transform for the fire point and reference to bullet prefab
    public Transform SMGFirePoint;
    public GameObject SMGBulletPrefab;

    // Smg float Variables
    public float SMGdamage = 35f;
    public float SMGrange = 70f;
    public float SMGfireRate = 30f;
    public float SMGreloadTime = 2.5f;
    private float SMGnextTimeToFire = 2f;

    // SMG int variables
    public int SMGmaxAmmo = 15;
    public int SMGcurrentAmmo = 15;
    public int SMGClipSize = 15;
    public int SMGTotalMaxAmmo = 150;

    // SMG bools
    public bool hasSMGGotAmmo = true;
    private bool isSMGReloading = false;
    
    

    // Bullet force/speed
    public float M4bulletForce = 40f;

    //Transform for the fire point and reference to bullet prefab
    public Transform M4FirePoint;
    public GameObject M4BulletPrefab;

    // M4 float variables
    public float M4damage = 50f;
    public float M4range = 90f;
    public float M4fireRate = 40f;
    public float M4reloadTime = 4f;
    private float M4nextTimeToFire = 3f;

    // M4 int variables
    public int M4maxAmmo = 30;
    public int M4currentAmmo = 30;
    public int M4ClipSize = 30;
    public int M4TotalMaxAmmo = 300;

    // M4 bools
    public bool hasM4GotAmmo = true;
    private bool isM4Reloading = false;
    

    // Bullet force/speed
    public float AKbulletForce = 50f;

    //Transform for the fire point and reference to bullet prefab
    public Transform AKFirePoint;
    public GameObject AKBulletPrefab;

    // AK float variables
    public float AKdamage = 65f;
    public float AKrange = 95f;
    public float AKfireRate = 50f;
    public float AKreloadTime = 4.5f;
    private float AKnextTimeToFire = 3.5f;

    // AK int variables
    public int AKmaxAmmo = 40;
    public int AKcurrentAmmo = 40;
    public int AKClipSize = 40;
    public int AKTotalMaxAmmo = 440;

    // AK Bools
    public bool hasAKGotAmmo = true;
    private bool isAKReloading = false;
    

    // Bullet force/speed
    public float P90bulletForce = 70f;

    //Transform for the fire point and reference to bullet prefab
    public Transform P90FirePoint;
    public GameObject P90BulletPrefab;

    // P90 float variables
    public float P90damage = 80f;
    public float P90range = 90f;
    public float P90fireRate = 60f;
    public float P90reloadTime = 5f;
    private float P90nextTimeToFire = 4f;

    // P90 int variables
    public int P90maxAmmo = 60;
    public int P90currentAmmo = 60;
    public int P90ClipSize = 60;
    public int P90TotalMaxAmmo = 660;

    // P90 bools
    public bool hasP90GotAmmo = true;
    private bool isP90Reloading = false;
    


    // Bools for which gun is currently active
    public bool IsWhitePistolTrue = false;
    public bool IsGreenSMGTrue = false;
    public bool IsBlueM4True = false;
    public bool IsPinkAKTrue = false;
    public bool IsRedP90True = false;



    // On start
    void Start()
    {
        // set white pistol to true
        IsWhitePistolTrue = true;

        // Show player they need to reload
        ReloadGunText.gameObject.SetActive(false);

        // set all weapons to their clip sizes
        PistolcurrentAmmo = 6;
        SMGcurrentAmmo = 15;
        M4currentAmmo = 30;
        AKcurrentAmmo = 40;
        P90currentAmmo = 60;
    }

    // on enable
    void OnEnable()
    {
        // set all reloading to false
        isPistolReloading = false;
        isSMGReloading = false;
        isM4Reloading = false;
        isAKReloading = false;
        isP90Reloading = false;
    }

    void Update()
    {
        // if player has white pistol
        if (IsWhitePistolTrue)
        {
            // Set white is true and green, blue and pink is false for wall buy
            moneyManager.WhiteIsTrue();
            moneyManager.GreenIsNotTrue();
            moneyManager.BlueIsNotTrue();
            moneyManager.PinkIsNotTrue();

            // set current and reserve pistol ammo to true
            CurrentPistolAmmoText.gameObject.SetActive(true);
            ReservePistolAmmoText.gameObject.SetActive(true);

            // Set SMG weapon text to false
            CurrentSMGAmmoText.gameObject.SetActive(false);
            ReserveSMGAmmoText.gameObject.SetActive(false);

            // Set M4 weapon text to false
            CurrentM4AmmoText.gameObject.SetActive(false);
            ReserveM4AmmoText.gameObject.SetActive(false);

            // Set AK weapon text to false
            CurrentAKAmmoText.gameObject.SetActive(false);
            ReserveAKAmmoText.gameObject.SetActive(false);

            // Set P90 weapon text to false
            CurrentP90AmmoText.gameObject.SetActive(false);
            ReserveP90AmmoText.gameObject.SetActive(false);

            // Set all other guns to false
            IsGreenSMGTrue = false;
            IsBlueM4True = false;
            IsPinkAKTrue = false;
            IsRedP90True = false;

            // If the pistolisreloading = true, return
            if (isPistolReloading)
                return;

            // if the left mouse button is pressed and pistol has ammo and can fire
            if (Input.GetButtonDown("Fire1") && Time.time >= PistolnextTimeToFire && hasPistolGotAmmo)
            {
                // Set the next time pistol can fire
                PistolnextTimeToFire = Time.time + 1f / PistolfireRate;
                
                // Shoot pistol
                ShootPistol();
            }

            // if pistol current ammo is less than 0
            if (PistolcurrentAmmo < 0)
            {
                //pistol current ammo = 0
                PistolcurrentAmmo = 0;

                // if pistol max ammo is more than 0
                if (PistolmaxAmmo > 0)
                {
                    // reload pistol
                    StartCoroutine(ReloadPistol());
                    return;
                }
                
                // if pistol max ammo is less 0
                if (PistolmaxAmmo < 0)
                {
                    // pistol max ammo = 0
                    PistolmaxAmmo = 0;
                }

            }
            
            // if R is pressed
            if (Input.GetKeyDown(KeyCode.R))
            {
                // reload
                StartCoroutine(ReloadPistol());
                return;
            }

            // Set pistol current and reserve text to current and max ammo
            CurrentPistolAmmoText.text = "" + PistolcurrentAmmo.ToString();
            ReservePistolAmmoText.text = "" + PistolmaxAmmo.ToString();

            // If current ammo is less than or = 0, show player they need to reload
            if (PistolcurrentAmmo <= 0)
            {
                ReloadGunText.gameObject.SetActive(true);
            }

        }

        // if player has green SMG
        if (IsGreenSMGTrue)
        {
            // Set green is true and white, blue and pink is false for wall buy
            moneyManager.GreenIsTrue();
            moneyManager.WhiteIsNotTrue();
            moneyManager.BlueIsNotTrue();
            moneyManager.PinkIsNotTrue();

            // set current and reserve pistol ammo to false
            CurrentPistolAmmoText.gameObject.SetActive(false);
            ReservePistolAmmoText.gameObject.SetActive(false);

            // set current and reserve SMG ammo to true
            CurrentSMGAmmoText.gameObject.SetActive(true);
            ReserveSMGAmmoText.gameObject.SetActive(true);

            // set current and reserve M4 ammo to false
            CurrentM4AmmoText.gameObject.SetActive(false);
            ReserveM4AmmoText.gameObject.SetActive(false);

            // set current and reserve AK ammo to false
            CurrentAKAmmoText.gameObject.SetActive(false);
            ReserveAKAmmoText.gameObject.SetActive(false);

            // set current and reserve P90 ammo to false
            CurrentP90AmmoText.gameObject.SetActive(false);
            ReserveP90AmmoText.gameObject.SetActive(false);

            // Set all other guns to false
            IsWhitePistolTrue = false;
            IsBlueM4True = false;
            IsPinkAKTrue = false;
            IsRedP90True = false;

            // If the SMGisreloading = true, return
            if (isSMGReloading)
                return;

            // if the left mouse button is pressed and SMG has ammo and can fire
            if (Input.GetButtonDown("Fire1") && Time.time >= SMGnextTimeToFire && hasSMGGotAmmo)
            {
                // Set the next time SMG can fire
                SMGnextTimeToFire = Time.time + 1f / SMGfireRate;

                // Shoot SMG
                ShootSMG();
            }

            // if SMG current ammo is less than 0
            if (SMGcurrentAmmo < 0)
            {
                // SMG current ammo = 0
                SMGcurrentAmmo = 0;
                
                // if SMG max ammo is more than 0
                if (SMGmaxAmmo > 0)
                {
                    // Reload SMG
                    StartCoroutine(ReloadSMG());
                    return;
                }

                // if SMG max ammo is less than or = 0
                if (SMGmaxAmmo < 0)
                {
                    // SMG max ammo = 0
                    SMGmaxAmmo = 0;
                }

            }
            
            // if R is pressed
            if (Input.GetKeyDown(KeyCode.R))
            {
                // Reload
                StartCoroutine(ReloadSMG());
                return;
            }

            // Set SMG current and reserve text to current and max ammo
            CurrentSMGAmmoText.text = "" + SMGcurrentAmmo.ToString();
            ReserveSMGAmmoText.text = "" + SMGmaxAmmo.ToString();

            // If current ammo is less than or = 0, show player they need to reload
            if (SMGcurrentAmmo <= 0)
            {
                ReloadGunText.gameObject.SetActive(true);
            }

        }
        
        // if player has blue M4
        if (IsBlueM4True)
        {
            // Set blue is true and white, green and pink is false for wall buy
            moneyManager.GreenIsNotTrue();
            moneyManager.WhiteIsNotTrue();
            moneyManager.BlueIsTrue();
            moneyManager.PinkIsNotTrue();

            // set current and reserve pistol ammo to false
            CurrentPistolAmmoText.gameObject.SetActive(false);
            ReservePistolAmmoText.gameObject.SetActive(false);

            // set current and reserve SMG ammo to false
            CurrentSMGAmmoText.gameObject.SetActive(false);
            ReserveSMGAmmoText.gameObject.SetActive(false);

            // set current and reserve M4 ammo to true
            CurrentM4AmmoText.gameObject.SetActive(true);
            ReserveM4AmmoText.gameObject.SetActive(true);

            // set current and reserve AK ammo to false
            CurrentAKAmmoText.gameObject.SetActive(false);
            ReserveAKAmmoText.gameObject.SetActive(false);

            // set current and reserve P90 ammo to false
            CurrentP90AmmoText.gameObject.SetActive(false);
            ReserveP90AmmoText.gameObject.SetActive(false);

            // Set all other guns to false
            IsWhitePistolTrue = false;
            IsGreenSMGTrue = false;
            IsPinkAKTrue = false;
            IsRedP90True = false;

            // If the M4isreloading = true, return
            if (isM4Reloading)
                return;

            // if the left mouse button is pressed and M4 has ammo and can fire
            if (Input.GetButtonDown("Fire1") && Time.time >= M4nextTimeToFire && hasM4GotAmmo)
            {
                // Set the next time M4 can fire
                M4nextTimeToFire = Time.time + 1f / M4fireRate;

                // Shoot M4
                ShootM4();
            }

            // If M4 current ammo is less than 0
            if (M4currentAmmo < 0)
            {
                // M4 current ammo = 0
                M4currentAmmo = 0;

                // If M4 max ammo is more than = 0
                if (M4maxAmmo > 0)
                {
                    // Reload M4
                    StartCoroutine(ReloadM4());
                    return;
                }

                // If M4 max ammo is less than or = 0
                if (M4maxAmmo < 0)
                {
                    // M4 max ammo = 0
                    M4maxAmmo = 0;
                }

            }

            // If R is pressed
            if (Input.GetKeyDown(KeyCode.R))
            {
                // Reload M4
                StartCoroutine(ReloadM4());
                return;
            }

            // Set M4 current and reserve text to current and max ammo
            CurrentM4AmmoText.text = "" + M4currentAmmo.ToString();
            ReserveM4AmmoText.text = "" + M4maxAmmo.ToString();

            // If current ammo is less than or = 0, show player they need to reload
            if (M4currentAmmo <= 0)
            {
                ReloadGunText.gameObject.SetActive(true);
            }

        }

        // if player has Pink AK
        if (IsPinkAKTrue)
        {
            // Set pink is true and white, blue and green is false for wall buy
            moneyManager.GreenIsNotTrue();
            moneyManager.WhiteIsNotTrue();
            moneyManager.BlueIsNotTrue();
            moneyManager.PinkIsTrue();

            // set current and reserve pistol ammo to false
            CurrentPistolAmmoText.gameObject.SetActive(false);
            ReservePistolAmmoText.gameObject.SetActive(false);

            // set current and reserve SMG ammo to false
            CurrentSMGAmmoText.gameObject.SetActive(false);
            ReserveSMGAmmoText.gameObject.SetActive(false);

            // set current and reserve M4 ammo to false
            CurrentM4AmmoText.gameObject.SetActive(false);
            ReserveM4AmmoText.gameObject.SetActive(false);

            // set current and reserve AK ammo to true
            CurrentAKAmmoText.gameObject.SetActive(true);
            ReserveAKAmmoText.gameObject.SetActive(true);

            // set current and reserve P90 ammo to false
            CurrentP90AmmoText.gameObject.SetActive(false);
            ReserveP90AmmoText.gameObject.SetActive(false);

            // Set all other guns to false
            IsWhitePistolTrue = false;
            IsGreenSMGTrue = false;
            IsBlueM4True = false;
            IsRedP90True = false;

            // If the AKisreloading = true, return
            if (isAKReloading)
                return;

            // if the left mouse button is pressed and AK has ammo and can fire
            if (Input.GetButtonDown("Fire1") && Time.time >= AKnextTimeToFire && hasAKGotAmmo)
            {
                // Set the next time AK can fire
                AKnextTimeToFire = Time.time + 1f / AKfireRate;

                // Shoot AK
                ShootAK();
            }

            // If AK current ammo is less than 0
            if (AKcurrentAmmo < 0)
            {
                // AK current ammo = 0
                AKcurrentAmmo = 0;

                // if AK max ammo is more than 0
                if (AKmaxAmmo > 0)
                {
                    // Reload AK
                    StartCoroutine(ReloadAK());
                    return;
                }

                // If AK max ammo is less than or = 0
                if (AKmaxAmmo < 0)
                {
                    // AK max ammo = 0
                    AKmaxAmmo = 0;
                }

            }

            // if R is pressed
            if (Input.GetKeyDown(KeyCode.R))
            {
                // Reload AK
                StartCoroutine(ReloadAK());
                return;
            }

            // Set AK current and reserve text to current and max ammo
            CurrentAKAmmoText.text = "" + AKcurrentAmmo.ToString();
            ReserveAKAmmoText.text = "" + AKmaxAmmo.ToString();

            // If current ammo is less than or = 0, show player they need to reload
            if (AKcurrentAmmo <= 0)
            {
                ReloadGunText.gameObject.SetActive(true);
            }

        }

        // Is player has red P90
        if (IsRedP90True)
        {
            // Set white and green is false for wall buy
            moneyManager.WhiteIsNotTrue();
            moneyManager.GreenIsNotTrue();
            moneyManager.BlueIsNotTrue();
            moneyManager.PinkIsNotTrue();

            // set current and reserve pistol ammo to false
            CurrentPistolAmmoText.gameObject.SetActive(false);
            ReservePistolAmmoText.gameObject.SetActive(false);

            // set current and reserve SMg ammo to false
            CurrentSMGAmmoText.gameObject.SetActive(false);
            ReserveSMGAmmoText.gameObject.SetActive(false);

            // set current and reserve M4 ammo to false
            CurrentM4AmmoText.gameObject.SetActive(false);
            ReserveM4AmmoText.gameObject.SetActive(false);

            // set current and reserve AK ammo to false
            CurrentAKAmmoText.gameObject.SetActive(false);
            ReserveAKAmmoText.gameObject.SetActive(false);

            // set current and reserve P90 ammo to true
            CurrentP90AmmoText.gameObject.SetActive(true);
            ReserveP90AmmoText.gameObject.SetActive(true);

            // Set all other guns to false
            IsWhitePistolTrue = false;
            IsGreenSMGTrue = false;
            IsBlueM4True = false;
            IsPinkAKTrue = false;

            // If the P90isreloading = true, return
            if (isP90Reloading)
                return;

            // if the left mouse button is pressed and P90 has ammo and can fire
            if (Input.GetButtonDown("Fire1") && Time.time >= P90nextTimeToFire && hasP90GotAmmo)
            {
                // Set the next time P90 can fire
                P90nextTimeToFire = Time.time + 1f / P90fireRate;

                // Shoot P90
                ShootP90();
            }

            // If P90 current ammo is less than 0
            if (P90currentAmmo < 0)
            {
                // P90 current ammo = 0
                P90currentAmmo = 0;

                // If P90 max ammo is more than 0
                if (P90maxAmmo > 0)
                {
                    // Reload P90
                    StartCoroutine(ReloadP90());
                    return;
                }

                // if P90 max ammo is less than or = 0
                if (P90maxAmmo < 0)
                {
                    // P90 max ammo = 0
                    P90maxAmmo = 0;
                }

            } 

            // If R is pressed
            if (Input.GetKeyDown(KeyCode.R))
            {
                // Reload P90
                StartCoroutine(ReloadP90());
                return;
            }

            // Set P90 current and reserve text to current and max ammo
            CurrentP90AmmoText.text = "" + P90currentAmmo.ToString();
            ReserveP90AmmoText.text = "" + P90maxAmmo.ToString();

            // If current ammo is less than or = 0, show player they need to reload
            if (P90currentAmmo <= 0)
            {
                ReloadGunText.gameObject.SetActive(true);
            }

        }

    }








    // Reload Pistol
    IEnumerator ReloadPistol()
    {
        // Set reloading to true
        isPistolReloading = true;
        
        // wait for reload time
        yield return new WaitForSeconds(PistolreloadTime);

        // max ammo - the current ammo used 
        PistolmaxAmmo -= Mathf.Clamp(PistolClipSize - PistolcurrentAmmo, 0, PistolTotalMaxAmmo);

        ReloadGunText.gameObject.SetActive(false);

        // Set reloading to false
        isPistolReloading = false;

        // if reloading is false
        if (isPistolReloading == false)
        {
            // if pistol max ammo is less than 0
            if (PistolmaxAmmo < 0)
            {
                // set pistol reloading to false and got ammo to false
                isPistolReloading = false;
                hasPistolGotAmmo = false;
                PistolmaxAmmo = 0;
                yield break;
            }
            else
                // Set ammo to gun clip size
                PistolcurrentAmmo = 6;
        }

    }

    
    // Shoot pistol
    public void ShootPistol()
    {
        // If pistol current ammo is less than or = 0
        if (PistolcurrentAmmo <= 0)
        {
            
            // do nothing
            return;
        }
        
        // Takeaway one ammo
        PistolcurrentAmmo--;

        // Instantiate bullet at position
        GameObject bullet = Instantiate(PistolBulletPrefab, PistolFirePoint.position, PistolFirePoint.rotation);

        // Create Rigidbody for bullet
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        // Add Force/speed to bullet
        rb.AddForce(PistolFirePoint.right * PistolbulletForce, ForceMode2D.Impulse);
    }





    // Reload SMG
    IEnumerator ReloadSMG()
    {
        // Set reloading to true
        isSMGReloading = true;

        // wait for reload time
        yield return new WaitForSeconds(SMGreloadTime);

        // max ammo - the current ammo used 
        SMGmaxAmmo -= Mathf.Clamp(SMGClipSize - SMGcurrentAmmo, 0, SMGTotalMaxAmmo);

        ReloadGunText.gameObject.SetActive(false);

        // Set reloading to false
        isSMGReloading = false;

        // if reloading is false
        if (isSMGReloading == false)
        {
            // if SMG max ammo is less than 0
            if (SMGmaxAmmo < 0)
            {
                // set SMG reloading to false and got ammo to false
                isSMGReloading = false;
                hasSMGGotAmmo = false;
                SMGmaxAmmo = 0;
                yield break;
            }
            else
                // Set ammo to gun clip size
                SMGcurrentAmmo = 15;
        }


    }

    // Shoot SMG
    private void ShootSMG()
    {
        // If SMG current ammo is less than or = 0
        if (SMGcurrentAmmo <= 0)
        {
            // do nothing
            return;
        }

        // Takeaway one ammo
        SMGcurrentAmmo--;

        // Instantiate bullet at position
        GameObject bullet = Instantiate(SMGBulletPrefab, SMGFirePoint.position, SMGFirePoint.rotation);
        
        // Create Rigidbody for bullet
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        // Add Force/speed to bullet
        rb.AddForce(SMGFirePoint.right * SMGbulletForce, ForceMode2D.Impulse);
    }
    




    // Reload M4
    IEnumerator ReloadM4()
    {
        // Set reloading to true
        isM4Reloading = true;

        // wait for reload time
        yield return new WaitForSeconds(M4reloadTime);

        // max ammo - the current ammo used 
        M4maxAmmo -= Mathf.Clamp(M4ClipSize - M4currentAmmo, 0, M4TotalMaxAmmo);

        ReloadGunText.gameObject.SetActive(false);

        // Set reloading to false
        isM4Reloading = false;

        // if reloading is false
        if (isM4Reloading == false)
        {
            // if M4 max ammo is less than 0
            if (M4maxAmmo < 0)
            {
                // set M4 reloading to false and got ammo to false
                isM4Reloading = false;
                hasM4GotAmmo = false;
                M4maxAmmo = 0;
                yield break;
            }
            else
                // Set ammo to gun clip size
                M4currentAmmo = 30;
        }
    }

    // Shoot M4
    private void ShootM4()
    {
        // If M4 current ammo is less than or = 0
        if (M4currentAmmo <= 0)
        {
            // do nothing
            return;
        }

        // Takeaway one ammo
        M4currentAmmo--;

        // Instantiate bullet at position
        GameObject bullet = Instantiate(M4BulletPrefab, M4FirePoint.position, M4FirePoint.rotation);

        // Create Rigidbody for bullet
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        // Add Force/speed to bullet
        rb.AddForce(M4FirePoint.right * M4bulletForce, ForceMode2D.Impulse);
    }







    // Reload AK
    IEnumerator ReloadAK()
    {
        // Set reloading to true
        isAKReloading = true;

        // wait for reload time
        yield return new WaitForSeconds(AKreloadTime);

        // max ammo - the current ammo used 
        AKmaxAmmo -= Mathf.Clamp(AKClipSize - AKcurrentAmmo, 0, AKTotalMaxAmmo);

        ReloadGunText.gameObject.SetActive(false);

        // Set reloading to false
        isAKReloading = false;

        // if reloading is false
        if (isAKReloading == false)
        {
            // if AK max ammo is less than 0
            if (AKmaxAmmo < 0)
            {
                // set AK reloading to false and got ammo to false
                isAKReloading = false;
                hasAKGotAmmo = false;
                AKmaxAmmo = 0;
                yield break;
            }
            else
                // Set ammo to gun clip size
                AKcurrentAmmo = 40;
        }
    }

    //Shoot AK
    private void ShootAK()
    {
        // If AK current ammo is less than or = 0
        if (AKcurrentAmmo <= 0)
        {
            // do nothing
            return;
        }

        // Takeaway one ammo
        AKcurrentAmmo--;

        // Instantiate bullet at position
        GameObject bullet = Instantiate(AKBulletPrefab, AKFirePoint.position, AKFirePoint.rotation);

        // Create Rigidbody for bullet
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        // Add Force/speed to bullet
        rb.AddForce(AKFirePoint.right * AKbulletForce, ForceMode2D.Impulse);
    }







    // Reload P90
    IEnumerator ReloadP90()
    {
        // Set reloading to true
        isP90Reloading = true;

        // wait for reload time
        yield return new WaitForSeconds(P90reloadTime);

        // max ammo - the current ammo used 
        P90maxAmmo -= Mathf.Clamp(P90ClipSize - P90currentAmmo, 0, P90TotalMaxAmmo);

        ReloadGunText.gameObject.SetActive(false);

        // Set reloading to false
        isP90Reloading = false;

        // if reloading is false
        if (isP90Reloading == false)
        {
            // if P90 max ammo is less than 0
            if (P90maxAmmo < 0)
            {
                // set P90 reloading to false and got ammo to false
                isP90Reloading = false;
                hasP90GotAmmo = false;
                P90maxAmmo = 0;
                yield break;
            }
            else
                // Set ammo to gun clip size
                P90currentAmmo = 60;
        }
    }

    // Shoot P90
    private void ShootP90()
    {
        // If P90 current ammo is less than or = 0
        if (P90currentAmmo <= 0)
        {
            // do nothing
            return;
        }

        // Takeaway one ammo
        P90currentAmmo--;

        // Instantiate bullet at position
        GameObject bullet = Instantiate(P90BulletPrefab, P90FirePoint.position, P90FirePoint.rotation);

        // Create Rigidbody for bullet
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        // Add Force/speed to bullet
        rb.AddForce(P90FirePoint.right * P90bulletForce, ForceMode2D.Impulse);
    }



    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // If bullet collides with wall
        if (collision.gameObject.CompareTag("Wall"))
        {
            // Destroy the bullet
            Destroy(collision.gameObject);
        }
    }


    

}
