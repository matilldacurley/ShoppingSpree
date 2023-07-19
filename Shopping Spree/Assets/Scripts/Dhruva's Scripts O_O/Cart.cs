using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cart : MonoBehaviour
{
    public GameObject player;
    public float cartOffset = -0.184f;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerControllerExperiment.PCE.isCarting)
        {
            GetComponent<SpriteRenderer>().enabled = true;
        }
        else
        {
            GetComponent<SpriteRenderer>().enabled = false;
        }
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y + cartOffset, 0);
    }
}
