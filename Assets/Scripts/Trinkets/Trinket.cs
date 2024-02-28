using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshObstacle))]
public class Trinket: MonoBehaviour
{
    [SerializeField] public string trinketName { get; protected set; }
    [SerializeField] public int trinketPrice { get; protected set; }    

    [SerializeField] protected float trinketRange;    
}
