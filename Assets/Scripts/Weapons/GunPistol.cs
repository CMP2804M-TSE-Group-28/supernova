using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Weapons;

public class GunPistol : Weapon
{
    public override int GetRemainingAmmo() { return 6; }

    public override string GetName() { return "Your Fucking Mother"; }

    public override void Fire()
    {
        print("Pew Pew!");
    }
}
