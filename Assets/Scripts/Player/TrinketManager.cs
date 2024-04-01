using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrinketManager : MonoBehaviour, IObserver
{
    Player player;
    [SerializeField] GameObject[] trinketPrefabs;
    [SerializeField] GameObject[] trinketShadows;
    [SerializeField] Grid grid;
    Camera cam;
    LayerMask placeLayer;

    //Trinket values
    int selectedTrinket;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponentInParent<Player>();
        cam = Camera.main;
        player.AddObserver(this);

        for(int i = 0; i < trinketPrefabs.Length; i++)
        {
            trinketShadows[i] = Instantiate(trinketPrefabs[i].GetComponent<Trinket>().GetShadow());
        }

        selectedTrinket = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3Int gridPos = grid.WorldToCell(player.cursorPos);
        trinketShadows[selectedTrinket].transform.position = grid.GetCellCenterWorld(gridPos);

    }


    public void SelectTrinket(int trinket)
    {
        trinketShadows[selectedTrinket].SetActive(false);
        selectedTrinket = trinket - 1;
        trinketShadows[selectedTrinket] = trinketShadows[trinket - 1];
        trinketShadows[selectedTrinket].SetActive(true);
    }

    public void Place()
    {
        int price = trinketPrefabs[selectedTrinket].GetComponent<Trinket>().GetCoinPrice();
        if (player.coins - price >= 0)
        {
            player.AddCoin(-price);
            Instantiate(trinketPrefabs[selectedTrinket], trinketShadows[selectedTrinket].transform.position, UnityEngine.Quaternion.identity);
        }
    }

    public void OnNotify()
    {
        Place();
    }
}
