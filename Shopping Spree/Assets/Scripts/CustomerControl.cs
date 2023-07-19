using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerControl : MonoBehaviour
{
    public GameObject wantItem;
    public int collect;
    public GameObject bar;
    public GameObject thoughtBubble;

    // Start is called before the first frame update
    void Start()
    {
        bar.SetActive(true);
        thoughtBubble.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
