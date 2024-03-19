using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealFountain : Turret 
{
    protected void Awake()
    {
        trinketPrice = 150;
    }

    protected override void Start()
    {
        range.radius = trinketRange;
        targetMask = LayerMask.GetMask("Player");
        base.Start();
    }

    private void Update()
    {
        Debug.Log(trinketPrice);
    }

    protected override void Shoot()
    {
        target.GetComponent<Player>().TakeDamage(5);
        canShoot = false;
        Invoke("ResetShot", fireRate * 0.1f);
    }

    protected override void ResetShot()
    {
        base.ResetShot();
    }
}
