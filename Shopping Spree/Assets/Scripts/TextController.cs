using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextController : MonoBehaviour
{
    private bool isGameActive = false;
    public GameObject titleScreen;
    // Start is called before the first frame update
    void Start()
    {
        titleScreen.SetActive(true);
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            isGameActive = true;
            titleScreen.SetActive(false);
        }
    }
}
