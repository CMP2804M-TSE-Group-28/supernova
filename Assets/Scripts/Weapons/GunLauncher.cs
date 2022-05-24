// This script holds the code that's ran when a launcher is used.

using UnityEngine;
using Weapons;

public class GunLauncher : Weapon
{
    public Camera cam;
    
    public Transform shotPoint;
    public GameObject prefabBullet;

    public AudioSource audioSrc;
    public AudioClip sfxShoot;
    public AudioClip sfxEmpty;

    private void Start()
    {
        RemainingAmmo = 100;
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

            print("Cam Pos");
            print(cam.transform.rotation);
            
            print("forward");
            print(transform.forward);
            
            Vector3 forward = cam.transform.TransformDirection(Vector3.forward * 250f);
            instanceBullet.GetComponent<Rigidbody>().AddForce(forward);
            
            // Update Remaining Ammo    
            UseAmmo();

                        // destroy instanceBullet after 1.0f seconds
            Destroy(instanceBullet, 3.0f);
        }
        else
        {
            audioSrc.PlayOneShot(sfxEmpty, .7f);
            Debug.Log("I'm out of ammo");
        }
    }
}
