using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerControl : MonoBehaviour
{
    public GameObject[] items;
    public int wantItem;
    public GameObject bar;
    public GameObject thoughtBubble;

    // Start is called before the first frame update
    void Start()
    {
        wantItem = Random.Range(0, 3 - 1);
        bar.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
