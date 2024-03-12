using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerStats : MonoBehaviour, IDamageable
{
    [SerializeField] private TMP_Text coinsText;
    [SerializeField] private TMP_Text woodText;

    public float health { get; private set; }
    public int coins { get; private set; }
    public int wood { get; private set; }

    private void Start()
    {
        health = 100;
        coins = 100;
        wood = 20;

        coinsText.text = "Coins: " + coins;
        woodText.text = "Wood: " + wood;
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

    public void AddWood(int amount)
    {
        wood += amount;
        woodText.text = "Wood: " + wood;
    }

    public bool Purchase()
    {
        if (0 <= (coins - GameManager.Instance.trinketPrice) && 0 <= (wood - GameManager.Instance.trinketWood))
        {
            coins -= GameManager.Instance.trinketPrice;
            coinsText.text = "Coins: " + coins;
            wood -= GameManager.Instance.trinketWood;
            woodText.text = "Wood: " + wood;
            return true;
        }
        return false;
    }

    public void Die()
    {
        Destroy(this.gameObject);
    }
}
