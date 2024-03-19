using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sniper: Turret 
{
    protected override void Shoot()
    {
        GameObject currentBullet = Instantiate(bulletPrefab, bulletSpawn);
        currentBullet.GetComponent<Projectile>().Initialize(target, damage);
        canShoot = false;
        Invoke("ResetShot", fireRate * 0.1f);
    }
}
