using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : Trinket 
{
    [SerializeField] protected GameObject turretPivot;
    [SerializeField] protected Transform bulletSpawn;
    [SerializeField] protected SphereCollider range;
    
    [SerializeField] protected TurretData data;


    protected GameObject target;
    private Vector3 targetPos;
    protected bool canShoot = true;
    private Collider[] shootQueue;

    // Start is called before the first frame update
    protected void Start()
    {       
        range.radius = data.trinketRange;
    }

    void FixedUpdate()
    {
        if (target == null)
        {
            shootQueue = Physics.OverlapSphere(transform.position, data.trinketRange, data.targetMask);
        }

        if (shootQueue.Length > 0)
        {
            target = shootQueue[0].gameObject;
            targetPos = new Vector3(target.transform.position.x, turretPivot.transform.position.y, target.transform.position.z);
            turretPivot.transform.LookAt(targetPos);

            if(canShoot)
            {
                Shoot();
            }
        }
        else
        {
            target = null;
        }
    }

    protected virtual void Shoot()
    {
        GameObject currentBullet = Instantiate(data.bulletPrefab, bulletSpawn);
        currentBullet.GetComponent<Projectile>().Initialize(target, data.damage);
        canShoot = false;
        Invoke("ResetShot", data.fireRate * 0.1f);
    }

    protected virtual void ResetShot()
    {
        canShoot = true;
    }

    public override GameObject GetShadow()
    {
        return data.shadowPrefab;
    }
}