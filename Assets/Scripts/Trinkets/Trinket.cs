using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshObstacle))]
public class Trinket: MonoBehaviour
{
    [SerializeField] protected string trinketName;
    [SerializeField] protected float trinketRange;    
}
