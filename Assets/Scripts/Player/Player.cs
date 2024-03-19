using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player: MonoBehaviour, IDamageable
{
    public float health { get; private set; }
    public int coins { get; private set; }
    public int wood { get; private set; }

    public PlayerSubject playerSubject { get; private set; }

    private void Awake()
    {
        playerSubject = new PlayerSubject();
    }

    private void Start()
    {
        health = 100;
        coins = 100;
        wood = 20;
    }

    private void FixedUpdate()
    {
        if (health <= 0)
        {
            Die();
        }

        playerSubject.locX = transform.position.x;
        playerSubject.locY = transform.position.z;
    }

    public void TakeDamage(float damage)
    {
        Debug.Log("OUCH!!!");
        health -= damage;
    }

    public void AddCoin(int amount)
    {
        coins += amount;
    }

    public void AddWood(int amount)
    {
        wood += amount;
    }

    public bool Purchase()
    {
        return false;
    }

    public void Die()
    {
        Destroy(this.gameObject);
    }
}
