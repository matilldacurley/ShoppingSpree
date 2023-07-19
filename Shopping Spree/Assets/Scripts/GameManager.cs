using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isGameActive = true;
            titleScreen.SetActive(false);
        }
    }
}
