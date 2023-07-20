using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerControl : MonoBehaviour
{
    public GameObject wantItem;
    public GameObject bar;
    public GameObject thoughtBubble;
    public bool collected = false;
    public int value = 1;

    // Start is called before the first frame update
    void Start()
    {
        //wantItem = transform.GetChild(1).GetComponent<ThoughtBubble>().pickedItem();
        bar.SetActive(true);
        thoughtBubble.SetActive(true);
        print("want: " + wantItem.GetComponent<ItemController>().id);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        print("jhhabrfb:" + other.gameObject.GetComponent<ItemController>().id);
        if(other.gameObject.GetComponent<ItemController>().id == wantItem.GetComponent<ItemController>().id)
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
            GameManager.gameManager.AddPoints(value);

        }

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
        if(transform.GetChild(0).GetComponent<Bar>().time_remaining <= 0)
        {
            Destroy(gameObject);
        }
    }
}
