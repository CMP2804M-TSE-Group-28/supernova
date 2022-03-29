using System;
using UnityEngine;
using System.Collections.Generic;

public class WeaponsHolder : MonoBehaviour
{
    public List<Weapons.Weapon> weapons;
    public int currentWeaponIndex = 0;

    public Weapons.Weapon CurrentWeapon => weapons[currentWeaponIndex];

    private void Start()
    {
        print($"among us imposter {currentWeaponIndex}");
        print(CurrentWeapon);
        print(CurrentWeapon.GetName());
    }
}