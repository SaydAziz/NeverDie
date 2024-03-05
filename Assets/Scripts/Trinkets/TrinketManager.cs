using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrinketManager : MonoBehaviour
{
    [SerializeField] GameObject[] trinketPrefabs;
    [SerializeField] GameObject[] trinketShadows;
    [SerializeField] GameObject cursor;
    [SerializeField] Grid grid;
    Camera cam;
    LayerMask placeLayer;

    //Trinket values
    Vector3 cursorPos;
    int selectedTrinket;
    GameObject currentShadow; 

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main; 
        placeLayer = LayerMask.GetMask("Place");
        selectedTrinket = 0;
        currentShadow = trinketShadows[selectedTrinket];
    }

    // Update is called once per frame
    void Update()
    {
        Vector3Int gridPos = grid.WorldToCell(cursorPos);
        cursor.transform.position = cursorPos;
        currentShadow.transform.position = grid.GetCellCenterWorld(gridPos); 

    }
    
    public void UpdateCursorPos(Vector2 mousePos)
    {
        Ray ray = cam.ScreenPointToRay(mousePos);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100, placeLayer))
        {
            cursorPos = hit.point;
        }
    }

    public void SelectTrinket(int trinket)
    {
        currentShadow.SetActive(false);
        selectedTrinket = trinket - 1;
        currentShadow = trinketShadows[trinket - 1];
        currentShadow.SetActive(true);
    }

    public void Place()
    {
        Instantiate(trinketPrefabs[selectedTrinket], currentShadow.transform.position, UnityEngine.Quaternion.identity);
    }
}
