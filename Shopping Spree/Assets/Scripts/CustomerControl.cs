using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerControl : MonoBehaviour
{
    public GameObject wantItem;
    public int collect;
    public GameObject bar;
    public GameObject thoughtBubble;
    public GameObject[] items;
    public int rand;
    public string name1;

    // Start is called before the first frame update
    void Start()
    {
        wantItem = transform.GetChild(0).GetComponent<ThoughtBubble>().pickedItem();
        bar.SetActive(true);
        thoughtBubble.SetActive(true);
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == wantItem.tag)
        {
            Destroy(col.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
