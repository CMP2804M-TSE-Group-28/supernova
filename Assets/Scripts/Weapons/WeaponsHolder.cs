using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Weapons;
using UnityEngine.UI;

public class WeaponsHolder : MonoBehaviour
{
    public List<Weapon> weapons;
    public int currentWeaponIndex = 0;
    public bool LauncherUnlocked = false;

    public Text AmmoText;
    public Text Message;

    private bool _firstTimeMessage = false;

    /// <summary>
    ///  Returns a pointer to the current selected weapon
    ///  To update what it's looking at, change the currentWeaponIndex.
    ///  This would normally be done inside of a UI handler.
    /// </summary>
    public Weapon CurrentWeapon => weapons[currentWeaponIndex];


    /// <summary>
    /// Handle user input when they press a fire button
    /// </summary>
    private void OnFire()
    {
        print($"Shooting with {CurrentWeapon.WeaponName}");
        CurrentWeapon.Fire();
    }

    private void Start()
    {
        foreach (Weapon weapon in weapons)
        {
            print($"I'm {weapon.WeaponName} I have {weapon.RemainingAmmo} shots...");
        }

        Message.gameObject.SetActive(false);
    }

    private void Update()
    {
        if(currentWeaponIndex == 0)
        {
            AmmoText.text = weapons[0].GetComponent<GunPistol>().RemainingAmmo.ToString();
        }
        else
        {
            AmmoText.text = weapons[1].GetComponent<GunLauncher>().RemainingAmmo.ToString();
        }

        if(LauncherUnlocked == true)
        {
            if (_firstTimeMessage == false)
            {
                _firstTimeMessage = true;
                StartCoroutine(DisplayMessage());
            }
        }
    }

    private void OnSwitchToPistol()
    {
        // Log
        print("Switching to Pistol");
        
        // Disable Last Weapon
        CurrentWeapon.WeaponModel.SetActive(false);
        
        // Switch to New Weapon
        currentWeaponIndex = 0;
        CurrentWeapon.WeaponModel.SetActive(true);
    }

    private void OnSwitchToRocketLauncher()
    {
        if (LauncherUnlocked)
        {
            // Log
            print("Switching to Rocket Launcher");

            // Disable Last Weapon
            CurrentWeapon.WeaponModel.SetActive(false);

            // Switch to New Weapon
            currentWeaponIndex = 1;
            CurrentWeapon.WeaponModel.SetActive(true);
        }
        else
        {
            print("Hey! Get the rocket launcher first... You need to kill the first boss, which isn't Revenant");
        }
    }

    private IEnumerator DisplayMessage()
    {
        Message.gameObject.SetActive(true);

        yield return new WaitForSeconds(4f);

        Message.gameObject.SetActive(false);
    }
}