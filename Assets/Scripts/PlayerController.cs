using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    VisualController vc;

    Vector2 moveDir;

    //Control Values
    [SerializeField] float moveSpeed = 12f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        vc = GetComponent<VisualController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        rb.MovePosition(rb.position + moveDir * moveSpeed * 0.01f);
        
    }


    public void DoMove(Vector2 value)
    {
        Debug.Log(value);
        moveDir = value;
        vc.UpdateMoveValues(value.x, value.magnitude);
    }
}
