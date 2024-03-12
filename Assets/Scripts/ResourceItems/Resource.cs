using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngineInternal;

[RequireComponent(typeof(Collider))]
public class Resource : MonoBehaviour
{
    int amount = 5;
    int id;

    private void OnTriggerEnter(Collider other)
    {
        PlayerStats player = other.GetComponent<PlayerStats>();
        if (player != null)
        {
            player.AddWood(amount);
            Destroy(this.gameObject);
        }
    }
}
