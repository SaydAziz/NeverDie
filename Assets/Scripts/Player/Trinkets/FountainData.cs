using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/FountainData")]
public class FountainData : TrinketData 
{
    public float trinketRange;
    public float effectAmount;
    public float fireRate;
    public LayerMask targetMask;
}
