using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    public int value = 10;
    public GameObject player;

    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        player = GameObject.Find("CustomerSpawn");
    }

    void Update()
    {

    }
    
}
