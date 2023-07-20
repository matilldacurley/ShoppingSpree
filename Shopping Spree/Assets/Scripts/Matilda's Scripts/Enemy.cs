using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject player;
    public Rigidbody2D rb;
    public float speed = 0.5f;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 lookDirection = (player.transform.position - transform.position).normalized;

        rb.velocity = (lookDirection * speed);
       
        if (rb.velocity != Vector2.zero)
        {
            anim.SetBool("isMoving", true);
        }
        else if (rb.velocity == Vector2.zero)
        {
            anim.SetBool("isMoving", false);
        }
    }
}
