using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThoughtBubble : MonoBehaviour
{
    public GameObject[] items;
    public int rand;
    public GameObject pitem;

    // Start is called before the first frame update
    void Start()
    {
        //rand = Random.Range(0, items.Length);
        //pitem = Instantiate(items[rand], new Vector3(transform.position.x, transform.position.y, -0.1f), items[rand].transform.rotation);
        //pitem.transform.SetParent(transform.parent);
        //name = 
    }

    public void disPlay()
    {
        //items[0].transform.SetParent(transform.parent);
        //Instantiate(items[0], transform.position, items[0].transform.rotation);
        pitem.SetActive(true);
    }

    public GameObject pickedItem()
    {
        rand = Random.Range(0, items.Length);
        pitem = Instantiate(items[rand], new Vector3(transform.position.x, transform.position.y, -0.1f), items[rand].transform.rotation);
        pitem.transform.SetParent(transform.parent);
        pitem.GetCompoent<BoxCollider2D>().enabled = false;
        return items[rand];
    }

    // Update is called once per frame
    void Update()
    {
        pitem.transform.position = new Vector3(transform.position.x, transform.position.y, -0.1f);
    }
}
