using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealFountain : Turret 
{
    protected override void Start()
    {
        range.radius = trinketRange;
        targetMask = LayerMask.GetMask("Player");
        trinketPrice = 150;
    }

    protected override void Shoot()
    {
        target.GetComponent<PlayerStats>().TakeDamage(5);
        canShoot = false;
        Invoke("ResetShot", fireRate * 0.1f);
    }

    protected override void ResetShot()
    {
        base.ResetShot();
    }
}
