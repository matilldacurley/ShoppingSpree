using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerControl : MonoBehaviour
{
    public GameObject[] items;
    public int wantItem;

    // Start is called before the first frame update
    void Start()
    {
        wantItem = Random.Range(0, items.Length - 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
