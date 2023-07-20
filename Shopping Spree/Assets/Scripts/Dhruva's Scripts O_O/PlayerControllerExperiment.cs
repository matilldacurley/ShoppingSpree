using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerExperiment : MonoBehaviour
{
    public static PlayerControllerExperiment PCE;
    private Rigidbody2D rb;
    public List<GameObject> ItemsCollected = new List<GameObject>();
    public GameObject spawnPoint;
    private float horizontal;
    private float vertical;
    public float baseRunSpeed = 1f;
    private float runSpeed;
    public float cartSpeed = 2.5f;
    public Vector3 bulletTarget;
    public bool isCarting = false;
    public GameObject[] Items;

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
            if(ItemsCollected.Count != 0)
            {
                bulletTarget = new Vector3(spawnpos.x, spawnpos.y, 0);
                ItemsCollected[0].SetActive(true);
                GameObject o = Instantiate(ItemsCollected[0], spawnPoint.transform.position, ItemsCollected[0].transform.rotation);
                o.GetComponent<SpriteRenderer>().enabled = true;
                o.GetComponent<ItemController>().bulletTarget = new Vector3(spawnpos.x, spawnpos.y, 0);
                o.GetComponent<ItemController>().StartMove();
                ItemsCollected.RemoveAt(0);
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
        ItemsCollected.Add(Items[other.GetComponent<ItemController>().id]);
        Destroy(other.gameObject);
    }

}