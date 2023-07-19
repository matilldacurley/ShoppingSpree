using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerExperiment : MonoBehaviour
{
    private Rigidbody2D rb;
    private GameObject Item = null;
    public GameObject throwPoint;
    private float horizontal;
    private float vertical;
    public float baseRunSpeed = 1f;
    private float runSpeed;
    public float cartSpeed = 2.5f;
    public float bulletSpeed = 0.75f;
    
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
        if(Input.GetMouseButtonDown(0))
        {
            if(Item != null)
            {
                Instantiate(Item, throwPoint.transform.position, Item.transform.rotation);
            }
            else
            {
                print("You Suck!");
            }
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        print("Picked Up!");
    }
}