using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerControl : MonoBehaviour
{
    public GameObject wantItem;
    public GameObject bar;
    public GameObject thoughtBubble;

    // Start is called before the first frame update
    void Start()
    {
        wantItem = transform.GetChild(1).GetComponent<ThoughtBubble>().pickedItem();
        bar.SetActive(true);
        thoughtBubble.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        /*
        if(other.transform.GetComponet<ItemController>())
        {
            
        }
        */
    }


    // public void OnTriggerEnter(Collider other)
    //{
    //print("collected");
    /*
    if (other.gameObject.tag == wantItem.tag)
    {
        Destroy(other.gameObject);
    }
    */
    //}


    // Update is called once per frame
    void Update()
    {
        
    }
}
