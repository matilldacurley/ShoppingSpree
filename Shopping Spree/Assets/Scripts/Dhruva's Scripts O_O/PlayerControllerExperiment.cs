using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerExperiment : MonoBehaviour
{
    public static PlayerControllerExperiment PCE;
    private Rigidbody2D rb;
    private GameObject Item;
    private float horizontal;
    private float vertical;
    public float baseRunSpeed = 1f;
    private float runSpeed;
    public float cartSpeed = 2.5f;
    public Vector3 bulletTarget;
    public bool isThrown = false;

    void Start()
    {
        PCE = this;
        rb = GetComponent<Rigidbody2D>();
        runSpeed = baseRunSpeed;
    }

    void Update()
    {
        Vector3 spawnpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
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
                bulletTarget = spawnpos;
                isThrown = true;
                Item.SetActive(true);
                GameObject o = Instantiate(Item, new Vector3(spawnpos.x, spawnpos.y, 0), Item.transform.rotation);
                o.GetComponent<ItemController>().bulletTarget = new Vector3(spawnpos.x, spawnpos.y, 0);
            }
            else
            {
                print("null");
            }
        }
        if (horizontal == -1)
        {
            transform.localScale = new Vector3(-1 * Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        if (horizontal == 1)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Item = other.gameObject;
         Item.SetActive(false);
    }
}