using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/TurretData")]
public class TurretData : ScriptableObject 
{
    public string trinketName;
    public int trinketGoldPrice;
    public int trinketWoodPrice;
    public float trinketRange;
    public GameObject bulletPrefab;
    public GameObject shadowPrefab;
    public float damage;
    public float fireRate;
    public LayerMask targetMask;
}
