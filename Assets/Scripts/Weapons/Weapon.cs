using UnityEngine;

namespace Weapons
{
    public abstract class Weapon : MonoBehaviour
    {
        public GameObject WeaponModel { get; set; }
        public int RemainingAmmo { get; set; }
        public string WeaponName { get; set; }
        
        // Methods
        public abstract void Fire();

        public void UseAmmo()
        {
            RemainingAmmo -= 1;
        }
    }
}