using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrinketManager : MonoBehaviour
{
    [SerializeField] GameObject[] trinketPrefabs;
    [SerializeField] GameObject cursor;
    Camera cam;
    LayerMask placeLayer;

    //Trinket values
    Vector3 cursorPos;
    int selectedTrinket;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main; 
        placeLayer = LayerMask.GetMask("Place");

        selectedTrinket = 0;
    }

    // Update is called once per frame
    void Update()
    {
        cursor.transform.position = cursorPos;
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

    public void Place()
    {
        Instantiate(trinketPrefabs[selectedTrinket], cursorPos, UnityEngine.Quaternion.identity);
    }
}
