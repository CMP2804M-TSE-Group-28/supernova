// This script holds the code that's ran when a launcher is used.

using UnityEngine;
using Weapons;

/*
firing sound received from: https://freesound.org/people/Mrthenoronha/sounds/517169/
*/

public class GunLauncher : Weapon
{
    public Camera cam;
    public GameObject _WeaponModel;

    public Transform shotPoint;
    public GameObject prefabBullet;

    public AudioSource audioSrc;
    public AudioClip sfxShoot;
    public AudioClip sfxEmpty;

    public int StartingAmmo = 25;

    [SerializeField] private float TTF = 1.0f;
    [SerializeField] private float coolDown = 0f;
    [SerializeField] private bool canFire = true;

    private void Start()
    {
        RemainingAmmo = StartingAmmo;
        WeaponName = "Rocket Launcher";
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

            //Play a sound. I'm doing this first for the immediate feedback.
            audioSrc.PlayOneShot(sfxShoot, .4f);

            // Create a bullet clone and send it forward.
            GameObject instanceBullet = Instantiate(prefabBullet, shotPoint.position,
                Quaternion.Euler((0 + shotPoint.eulerAngles.x), (0 + shotPoint.eulerAngles.y),
                    (90 + shotPoint.eulerAngles.z)));
            //GameObject projectile = GameObject.Find("/rockProj/Projectile");

            print("Cam Pos");
            print(cam.transform.rotation);

            print("forward");
            print(transform.forward);

            Vector3 forward = cam.transform.TransformDirection(Vector3.forward * 750f);
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