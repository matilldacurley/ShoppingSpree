using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThoughtBubble : MonoBehaviour
{
    public GameObject[] items;
    public int rand;
    

    // Start is called before the first frame update
    void Start()
    {
        rand = Random.Range(0, 3);
        //name = 
    }

    public void disPlay()
    {
        Instantiate(items[0], transform.position, items[0].transform.rotation);
    }

    public GameObject pickedItem()
    {
        return items[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
