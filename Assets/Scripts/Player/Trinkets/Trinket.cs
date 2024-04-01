using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Trinket : MonoBehaviour
{
    
    public abstract GameObject GetShadow();
    public abstract int GetCoinPrice();
}
