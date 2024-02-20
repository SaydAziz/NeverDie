using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    Rigidbody rb;

    //Movement Values
    Vector2 moveDir;
    float moveSpeed = 15;
    float moveDrag = 10;
    


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        rb.drag = moveDrag; 
    }

    private void FixedUpdate()
    {
        rb.AddForce(new Vector3(moveDir.x, 0, moveDir.y).normalized * moveSpeed * 10, ForceMode.Force);
        ClampSpeed();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ClampSpeed()
    {
        Vector3 vel = rb.velocity;
        if (vel.magnitude > moveSpeed)
        {
            Vector3 clampedVel = vel.normalized * moveSpeed;
            rb.velocity = new Vector3(clampedVel.x, rb.velocity.y, clampedVel.z);
        }
    }

    public void DoMovement(Vector2 value)
    {
        moveDir = value;
    }
}
