using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerExperiment : MonoBehaviour
{
    private Rigidbody2D rb;
    private float horizontal;
    private float vertical;
    public float baseRunSpeed = 1f;
    private float runSpeed;
    public float cartSpeed = 2.5f;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        runSpeed = baseRunSpeed;
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            runSpeed = cartSpeed;
        }
        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            runSpeed = baseRunSpeed;
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
    }
}