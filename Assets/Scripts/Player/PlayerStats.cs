using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerStats : MonoBehaviour, IDamageable
{
    [SerializeField] private TMP_Text coinsText;

    public float health { get; private set; }
    public float coins { get; private set; }

    public float trinketPrice;

    private void Start()
    {
        health = 100;
        coins = 150;
        trinketPrice = 50;

        coinsText.text = "Coins: " + coins;
    }

    private void FixedUpdate()
    {
        if (health <= 0)
        {
            Die();
        }
    }

    public void TakeDamage(float damage)
    {
        Debug.Log("OUCH!!!");
        health -= damage;
    }

    public void AddCoin(int amount)
    {
        coins += amount;
        coinsText.text = "Coins: " + coins;
    }

    public bool Purchase()
    {
        if (0 <= (coins - trinketPrice))
        {
            coins -= trinketPrice;
            coinsText.text = "Coins: " + coins;
            return true;
        }
        return false;
    }

    public void Die()
    {
        Destroy(this.gameObject);
    }
}
