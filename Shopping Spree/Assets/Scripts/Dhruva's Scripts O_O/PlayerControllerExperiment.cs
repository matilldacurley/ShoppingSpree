using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerExperiment : MonoBehaviour
{
    public static PlayerControllerExperiment PCE;
    private Rigidbody2D rb;
    private GameObject Item;
    public GameObject spawnPoint;
    private float horizontal;
    private float vertical;
    public float baseRunSpeed = 1f;
    private float runSpeed;
    public float cartSpeed = 2.5f;
    public Vector3 bulletTarget;
    public bool isThrown = false;
    public bool isCarting = false;

    public Animator anim;

    void Start()
    {
        PCE = this;
        rb = GetComponent<Rigidbody2D>();
        runSpeed = baseRunSpeed;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Vector3 spawnpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            isCarting = true;
            runSpeed = cartSpeed;
        }
        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            isCarting = false;
            runSpeed = baseRunSpeed;
        }
        if(Input.GetMouseButtonDown(0))
        {
            if(Item != null)
            {
                bulletTarget = new Vector3(spawnpos.x, spawnpos.y, 0);
                isThrown = true;
                Item.SetActive(true);
                GameObject o = Instantiate(Item, spawnPoint.transform.position, Item.transform.rotation);
                o.GetComponent<SpriteRenderer>().enabled = true;
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

        if (rb.velocity != Vector2.zero)
        {
            anim.SetBool("isMoving", true);
        }

        else if (rb.velocity == Vector2.zero)
        {
            anim.SetBool("isMoving", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Item = other.gameObject;
        //Item.SetActive(false);
        other.GetComponent<SpriteRenderer>().enabled = false;
    }

}