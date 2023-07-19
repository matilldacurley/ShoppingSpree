using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThoughtBubble : MonoBehaviour
{
    public GameObject[] items;

    // Start is called before the first frame update
    void Start()
    {
        //Instantiate(items[0], this.transform.position, items[0].transform.rotation);
    }

    public void disPlay()
    {
        Instantiate(items[0], transform.position, items[0].transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
