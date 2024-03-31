using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player: Subject, IDamageable
{
    public float health { get; private set; }
    public int coins { get; private set; }
    public int wood { get; private set; }

    public PlayerBeacon playerBeacon{ get; private set; }
    public Vector3 cursorPos { get; set; }

    private void Awake()
    {
        playerBeacon = new PlayerBeacon();
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

        playerBeacon.locX = transform.position.x;
        playerBeacon.locY = transform.position.z;
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

    public void Purchase()
    {
        NotifyObservers();
    }

    public void Die()
    {
        Destroy(this.gameObject);
    }
}
