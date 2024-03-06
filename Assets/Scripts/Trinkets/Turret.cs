using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : Trinket 
{
    [SerializeField] protected GameObject bulletPrefab;
    [SerializeField] protected GameObject turretPivot;
    [SerializeField] protected Transform bulletSpawn;
    [SerializeField] protected SphereCollider range;
    [SerializeField] protected float damage = 10;
    [SerializeField] protected float fireRate = 5f;


    protected LayerMask targetMask;
    protected GameObject target;
    private Vector3 targetPos;
    protected bool canShoot = true;
    private Collider[] shootQueue;

    protected void Awake()
    {
        trinketPrice = 50;
    }

    // Start is called before the first frame update
    protected override void Start()
    {       
        range.radius = trinketRange;
        targetMask = LayerMask.GetMask("Enemy");
        base.Start();
    }

    void FixedUpdate()
    {
        if (target == null)
        {
            shootQueue = Physics.OverlapSphere(transform.position, trinketRange, targetMask);
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
        GameObject currentBullet = Instantiate(bulletPrefab, bulletSpawn);
        currentBullet.GetComponent<Projectile>().Initialize(target, damage);
        canShoot = false;
        Invoke("ResetShot", fireRate * 0.1f);
    }

    protected virtual void ResetShot()
    {
        canShoot = true;
    }
}
