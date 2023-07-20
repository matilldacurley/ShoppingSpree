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
        print(wantItem.tag);
    }

    private void OnTriggerEnter(Collider other)
    {
        print("collected");
        if (other.gameObject.tag == wantItem.tag)
        {
            Destroy(other.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
