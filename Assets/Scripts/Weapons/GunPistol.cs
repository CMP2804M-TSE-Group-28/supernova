// This script holds the code that's ran when a pistol is used.

using UnityEngine;
using Weapons;

public class GunPistol : Weapon
{
    public Camera cam;
    public GameObject _WeaponModel;
    
    public Transform shotPoint;
    public GameObject prefabBullet;

    public AudioSource audioSrc;
    public AudioClip sfxShoot;
    public AudioClip sfxEmpty;

    private void Start()
    {
        RemainingAmmo = 100;
        WeaponName = "Pistol";
        WeaponModel = _WeaponModel;
    }

    
    // Implement here what you want to happen when the user fires the gun
    public override void Fire()
    {
        if (RemainingAmmo >= 0)
        {
            //Play a sound. I'm doing this first for the immediate feedback.
            audioSrc.PlayOneShot(sfxShoot, .7f);
        
            // Create a bullet clone and send it forward.
            GameObject instanceBullet = Instantiate(prefabBullet, shotPoint.position,  Quaternion.Euler((0 + shotPoint.eulerAngles.x), (0 + shotPoint.eulerAngles.y), (0 + shotPoint.eulerAngles.z)));

            Vector3 forward = cam.transform.TransformDirection(Vector3.forward * 2400f);
            instanceBullet.GetComponent<Rigidbody>().AddForce(forward);
            
            // Update Remaining Ammo    
            UseAmmo();
            
            // destroy instanceBullet after 1.0f seconds
            Destroy(instanceBullet, 1.0f);
        }
        else
        {
            audioSrc.PlayOneShot(sfxEmpty, .7f);
            Debug.Log("I'm out of ammo");
        }
    }
}
