using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Trinket : MonoBehaviour
{

    protected TrinketData data;
    public abstract GameObject GetShadow();
    public int GetCoinPrice()
    {
        return data.trinketCoinPrice;
    }
}
