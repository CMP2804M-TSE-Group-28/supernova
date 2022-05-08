using System;
using UnityEngine;
using System.Collections.Generic;
using Weapons;

public class WeaponsHolder : MonoBehaviour
{
    public List<Weapon> weapons;
    public int currentWeaponIndex = 0;

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
        CurrentWeapon.Fire();
    }
}