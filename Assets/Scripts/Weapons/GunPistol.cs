// This script holds the code that's ran when a pistol is used.

using UnityEngine;
using Weapons;

public class GunPistol : Weapon
{
    public Transform shotPoint;
    public GameObject prefabBullet;

    public AudioSource audioSrc;
    public AudioClip sfxShoot;
    public AudioClip sfxEmpty;

    private void Start()
    {
        RemainingAmmo = 6;
        WeaponName = "Pistol";
    }

    
    // Implement here what you want to happen when the user fires the gun
    public override void Fire()
    {
        if (RemainingAmmo >= 0)
        {
            //Play a sound. I'm doing this first for the immediate feedback.
            audioSrc.PlayOneShot(sfxShoot, .7f);
        
            // Create a bullet clone and send it forward.
            GameObject instanceBullet = Instantiate(prefabBullet, shotPoint.position, Quaternion.identity);
            instanceBullet.GetComponent<Rigidbody>().AddForce(transform.forward * 100f);
            
            // Update Remaining Ammo
            UseAmmo();
        }
        else
        {
            audioSrc.PlayOneShot(sfxEmpty, .7f);
            Debug.Log("I'm out of ammo");
        }
    }
}
