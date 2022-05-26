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

    [SerializeField] private MeshRenderer m; // mesh renderer of projectile, disabled on CreateExplosion

    [SerializeField] private float projTTL = 2.0f; // projectile will move forward for 2 seconds before exploding automatically
    [SerializeField] private GameObject prefabExplosion;
    [SerializeField] private float expTTL = 0.5f; // how long explosion stays

    private float sfxVol = 0.7f; // if we do global volume, then please edit this variable to use it.
    [SerializeField]private AudioSource audioSource; // source
    [SerializeField]private AudioClip audioClip; // sound

    private bool hasExploded = false;

    void FixedUpdate()
    {
        projTTL -= Time.deltaTime;

        if ((projTTL < 0f) && !hasExploded)
        {
            createExplosion();
            hasExploded = true;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!hasExploded)
        {
            Debug.Log("COLLIDED. EXPLOSION!!");
            createExplosion();
            hasExploded = true;
        }
    }

    public void createExplosion()
    {
        audioSource.PlayOneShot(audioClip, sfxVol); // play sound
        expTTL = 0.5f; // explosion only lasts 0.5 seconds
        GameObject instanceExplosion = Instantiate(prefabExplosion, transform.position, Quaternion.identity);

        Destroy(instanceExplosion, expTTL);

        m.enabled = false;
    }
}
