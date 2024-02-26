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
        

    GameObject target;
    Vector3 targetPos;
    bool canShoot = true;

    // Start is called before the first frame update
    void Start()
    {
        range.radius = trinketRange;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Enemy>() != null)
        {
            target = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Enemy>() != null)
        {
            target = null;
        }
    }

    void FixedUpdate()
    {
        if (target != null)
        {
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
