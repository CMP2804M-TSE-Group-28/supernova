using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
explosion sound received from: https://freesound.org/people/derplayer/sounds/587184/
*/

[RequireComponent(typeof(AudioSource))] // requires audiosource to work properly
public class Explosive : MonoBehaviour
{ // MADE BY VANTA - 
//This is placed onto the rocket launcher prefab itself - 
//  this determines the behaviour of the object.
// The launcher should be a child of the player to follow player's position and rotation for maximum effectiveness.

    //[SerializeField] private float moveSpeed = 1.5f; // movement speed of projectile
    //[SerializeField] private float range = 6f; // size of explosion sphere

    //[SerializeField] private GameObject projectile;
    [SerializeField] private float projTTL = 2.0f; // projectile will move forward for 2 seconds before exploding automatically
    [SerializeField] private GameObject explosion;
    [SerializeField] private float expTTL = 0.5f; // how long explosion stays

    private float sfxVol = 0.7f; // if we do global volume, then please edit this variable to use it.
    [SerializeField]private AudioSource audioSource; // source
    [SerializeField]private AudioClip audioClip; // sound

    //[SerializeField] private bool isFired = false;

    void Update()
    {
        /*
        if (!isFired)
        {
            return; // if already been fired, you can't shoot again until explosion appears
        }
        */

        projTTL -= Time.deltaTime;

        if (projTTL < 0f)
        {
            createExplosion();
        }

        expTTL -= Time.deltaTime;

        if (expTTL < 0f)
        {
            explosion.SetActive(false);
        }

    }

    void OnCollisionEnter(Collision collision)
    {
        //if (isFired) return;
        createExplosion();
        Debug.Log("reaches here");
    }
/*
    public void Fire(Transform aTransform) // takes position of entity that fired it
    {   
        Debug.Log("Fire() Called!!");
        if (isFired)
        {
            Debug.Log("HAS ALREADY BEEN FIRED!! returning...");
            return;
        }
        isFired = true;
    }
*/
    public void createExplosion()
    {
        audioSource.PlayOneShot(audioClip, sfxVol); // play sound
        //Vector3 projVector = projectile.transform.position; 
        expTTL = 0.5f; // explosion only lasts 0.5 seconds
        explosion.SetActive(true);
        //projVector, Quaternion.identity);
        MeshRenderer m = this.GetComponent<MeshRenderer>();
        m.enabled = false;
        //isFired = false; // rocket launcher can now be fired again
    }
}
