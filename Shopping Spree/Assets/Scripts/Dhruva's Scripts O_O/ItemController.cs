using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    private Rigidbody2D rb;
    public Vector3 bulletTarget;
    public float bulletSpeed = 1.25f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bulletTarget = (PlayerControllerExperiment.PCE.bulletTarget - PlayerControllerExperiment.PCE.transform.position).normalized;
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerControllerExperiment.PCE.isThrown)
        {
            //rb.velocity = bulletTarget * bulletSpeed;
            rb.velocity = new Vector2(bulletTarget.x * bulletSpeed, bulletTarget.y * bulletSpeed);
        }
    }
}
