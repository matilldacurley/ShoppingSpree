using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool isGameActive = false;
    public GameObject titleScreen;
    public AudioClip[] music;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        titleScreen.SetActive(true);
        audioSource.clip = music[0];
        audioSource.Play();
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            audioSource.Stop();
            isGameActive = true;
            titleScreen.SetActive(false);
            audioSource.clip = music[1];
            audioSource.Play();
        }
    }
}
