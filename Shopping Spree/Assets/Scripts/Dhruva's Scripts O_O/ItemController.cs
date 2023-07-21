using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    private Rigidbody2D rb;
    public Vector3 bulletTarget;
    public float bulletSpeed = 1.25f;
    public int id = 0;
    public bool isThrown = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void StartMove()
    {
        isThrown = true;
        rb = GetComponent<Rigidbody2D>();
        bulletTarget = (PlayerControllerExperiment.PCE.bulletTarget - PlayerControllerExperiment.PCE.transform.position).normalized;
        //rb.velocity = bulletTarget * bulletSpeed;
        rb.velocity = new Vector2(bulletTarget.x * bulletSpeed, bulletTarget.y * bulletSpeed);
    }

    

    // Update is called once per frame
    void Update()
    {
          
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("SpawnReject") && !isThrown)
        {
            Vector2 pos = new Vector2(Random.Range(-1, 1), Random.Range(-1, 1));
            transform.position = pos;
        }
        else if(other.CompareTag("SpawnReject") && isThrown)
        {
            rb.velocity = Vector2.zero;
        }
    }
}
