using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class PickupController : MonoBehaviour
{
    // PUBLIC DECLARATIONS
    [Header("Type of Pickup")] public bool IsHealth;
    public bool IsAmmo;

    [Header("General stats")] public int Value;

    [Header("Components")] public Transform SpritePlane;
    public Sprite Sprite;
    public AudioSource PickupSource;

    // PRIVATE DECLARATIONS
    private GameObject _playerEntity;
    private GameObject _weaponHolder;

    private void Start()
    {
        _playerEntity = GameObject.FindGameObjectWithTag("Player");
        _weaponHolder = GameObject.FindGameObjectWithTag("WeaponsHolder");
    }

    // Update is called once per frame
    private void Update()
    {
        // Look at player
        SpritePlane.LookAt(new Vector3(_playerEntity.transform.position.x,
            transform.position.y,
            _playerEntity.transform.position.z));

        SpritePlane.GetComponent<SpriteRenderer>().sprite = Sprite;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if (IsHealth)
            {
                PickupSource.Play();

                other.gameObject.GetComponent<Health>().Regenerate(Value);
                Destroy(gameObject, 0.5f);
            }
            else if (IsAmmo)
            {
                PickupSource.Play();

                _weaponHolder.GetComponent<WeaponsHolder>().weapons[0].GetComponent<GunPistol>().RemainingAmmo += Value;
                _weaponHolder.GetComponent<WeaponsHolder>().weapons[1].GetComponent<GunLauncher>().RemainingAmmo += Value;
                Destroy(gameObject, 0.5f);
            }
            Debug.Log("Player entered");
        }

        Debug.Log("Something entered");
    }
}
