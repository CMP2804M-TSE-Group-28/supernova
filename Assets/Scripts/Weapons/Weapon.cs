using UnityEngine;

namespace Weapons
{
    public abstract class Weapon : MonoBehaviour
    {
        public virtual string GetName()
        {
            return "name";
        }
    }
    
    public class ProjectileShooter : Weapon
    {
    }
}