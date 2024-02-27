using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : Trinket 
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] GameObject turretPivot;
    [SerializeField] Transform bulletSpawn;
    [SerializeField] SphereCollider range;
    [SerializeField] float damage = 10;
    [SerializeField] float fireRate = 5f;


    LayerMask enemyMask;
    GameObject target;
    Vector3 targetPos;
    bool canShoot = true;
    Collider[] shootQueue;

    // Start is called before the first frame update
    void Start()
    {
        range.radius = trinketRange;
        enemyMask = LayerMask.GetMask("Enemy");
    }

    void FixedUpdate()
    {
        if (target == null)
        {
            shootQueue = Physics.OverlapSphere(transform.position, trinketRange, enemyMask);
        }

        if (shootQueue != null)
        {
            target = shootQueue[0].gameObject;
            targetPos = new Vector3(target.transform.position.x, turretPivot.transform.position.y, target.transform.position.z);
            turretPivot.transform.LookAt(targetPos);

            if(canShoot)
            {
                Shoot();
            }
        }
    }

    void Shoot()
    {
        GameObject currentBullet = Instantiate(bulletPrefab, bulletSpawn);
        currentBullet.GetComponent<Projectile>().Initialize(target, damage);
        canShoot = false;
        Invoke("ResetShot", fireRate * 0.1f);
    }

    void ResetShot()
    {
        canShoot = true;
    }
}
