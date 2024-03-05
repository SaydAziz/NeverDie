using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] PlayerController player;
    [SerializeField] TrinketManager placer;

    public int trinketPrice { get; private set; }

    public static GameManager Instance;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        trinketPrice = 50; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateTrinketSelection(int selection)
    {
        placer.SelectTrinket(selection);
    }

    public void PlaceTrinket()
    {
        placer.Place(); 
    }

    public Vector3 GetPlayerLocation()
    {
        return player.transform.position;
    }

    public void SetTrinketPrice(int price)
    {
        trinketPrice = price;
    }
}
