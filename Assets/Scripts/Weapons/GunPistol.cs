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

    public int StartingAmmo = 200;

    [SerializeField] private float TTF = 0.33f;
    [SerializeField] private float coolDown = 0f;
    [SerializeField] private bool canFire = true;

    private void Start()
    {
        RemainingAmmo = StartingAmmo;
        WeaponName = "Pistol";
        WeaponModel = _WeaponModel;
    }

    private void FixedUpdate()
    {
        coolDown -= Time.fixedDeltaTime;

        if (coolDown < 0f)
        {
            canFire = true;
        }
    }
    
    // Implement here what you want to happen when the user fires the gun
    public override void Fire()
    {
        if (!canFire)
        {
            Debug.Log(WeaponName + " is shooting too fast!!");
            return;
        }
        if (RemainingAmmo >= 0)
        {
            // Gun now cannot fire until time runs out
            canFire = false;
            coolDown = TTF;

            // Play a sound. I'm doing this first for the immediate feedback.
            audioSrc.PlayOneShot(sfxShoot, .4f);
        
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
