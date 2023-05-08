using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BulletPool))]
public abstract class ShootBase : MonoBehaviour
{
    [SerializeField] private List<Transform> shootPoints;
    [SerializeField] internal GameObject bulletPrefab;
    [SerializeField] internal float bulletSpeed, reloadDelay;
    private float currentDelay;
    private Collider[] colliders;
    private bool canShoot = true;

    private BulletPool bulletPool;
    [SerializeField] private int bulletPoolCount = 10;
    protected virtual void Awake()
    {
        bulletPool = GetComponent<BulletPool>();
        colliders = GetComponentsInParent<Collider>();
    }
    protected virtual void Start()
    {
        bulletPool.Inýtýalize(bulletPrefab, bulletPoolCount);
    }
    protected virtual void Update()
    {
        if (canShoot == false)
        {
            currentDelay -= Time.deltaTime;
            if (currentDelay <= 0)
            {
                canShoot = true;
            }
        }
    }
    public virtual void Shoot(IDamageable damageable)
    {
        if (canShoot)
        {
            canShoot = false;
            currentDelay = reloadDelay;
            if (damageable != null)
            {
                foreach (var barrel in shootPoints)
                {

                    GameObject bullet = bulletPool.CreateObject();
                    bullet.transform.position = barrel.position;
                    bullet.transform.localRotation = barrel.rotation;
                    Vector3 direction = damageable.GetTransform().position - bullet.transform.position;
                    bullet.transform.LookAt(damageable.GetTransform());
                    bullet.GetComponent<Rigidbody>().velocity = direction * bulletSpeed;
                    foreach (var collider in colliders)
                    {
                        Physics.IgnoreCollision(bullet.GetComponent<Collider>(), collider);
                    }
                }
            }
        }


    }
}
