using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fountain : Trinket 
{
    [SerializeField] protected new FountainData data;

    private void Update()
    { 
    }

    public override GameObject GetShadow()
    {
        return data.shadowPrefab;
    }
    public override int GetCoinPrice()
    {
        return data.trinketCoinPrice;
    }
}
