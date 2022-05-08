using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Weapons
{
    public abstract class Weapon : MonoBehaviour
    {
        // Methods
        public abstract void Fire();
        
        // Properties
        public abstract int GetRemainingAmmo();
        public abstract string GetName();

        private void Awake()
        {
            print($"I'm {GetName()} I have {GetRemainingAmmo()} shots left...");
        }
    }
}