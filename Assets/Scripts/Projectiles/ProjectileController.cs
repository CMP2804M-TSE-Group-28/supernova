using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    [Header("Entity Scripts")]
    public ProjectileInfoEnemy Info;
    public ProjectileMovement Movement;

    [Header("Componets")]
    public Rigidbody ProjectileRigidbody;
    public Sprite ProjectileSprite;
    public Transform SpritePlane;

    // PRIVATE DELCARTIONS
    private Transform _playerPosition;
    private bool _hasExploded;

    private float _explosionDelayTimer = 0f;
    private float _explodeDelay = 2f;

    // Start is called before the first frame update
    void Start()
    {
        // Gets scripts
        Movement = GetComponent<ProjectileMovement>();
        ProjectileRigidbody = GetComponent<Rigidbody>();

        _playerPosition = GameObject.Find("PlayerTarget").transform;
    }

    private void Update()
    {
        SpritePlane.LookAt(_playerPosition);

        _explosionDelayTimer += Time.deltaTime;
    }

    public void GetProjectileInfo(GameObject EntityFiring)
    {
        // Gets projectile info
        Info = EntityFiring.GetComponent<EnemyRanged>().Info;

        // Sets all the necessary stats and components
        ProjectileSprite = Info.ProjectileSprite;
    }

    public void CreateExplosion()
    {
        GameObject _explosionVFX = Instantiate(Info.ExplosionVFX, transform.position, Quaternion.identity);

        Collider[] _entitiesInBlast = Physics.OverlapSphere(transform.position, 1.5f);
        foreach (var _collider in _entitiesInBlast)
        {
            if(_collider.gameObject.tag == "Player")
            {
                _collider.gameObject.GetComponent<Health>().TakeDamage(Info.Damage);
            }
            else if(_collider.gameObject.tag == "Enemy")
            {
                _collider.gameObject.GetComponent<EnemyController>().Health -= Info.Damage;
            }
            else if(_collider.gameObject.tag == "Breakable")
            {
                _collider.gameObject.SetActive(false);
            }
            else if(_collider.gameObject.tag == "NotRevenant")
            {
                _collider.gameObject.GetComponent<BossController_Revenant>().Health -= Info.Damage;
            }
        }

        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(Info.IsExplosiveType == true)
        {
            if(other.gameObject.tag == "Projectile")
            {
                Debug.Log("Projectile hit another projectile");
            }
            else
            {
                if (_hasExploded == false &&
                    _explosionDelayTimer >= _explodeDelay)
                {
                    _hasExploded = true;

                    CreateExplosion();
                }
            }
        }
        else
        {
            if (other.gameObject.tag == "Player")
            {
                other.GetComponent<Health>().TakeDamage(Info.Damage);
            }

            Destroy(gameObject);
        }
    }
}
