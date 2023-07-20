using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    private bool isGameActive = false;
    public int lives = 3;
    public GameObject titleScreen;
    public GameObject gameOverScreen;
    public AudioClip[] music;
    public AudioSource audioSource;
    public TextMeshProUGUI pointsText;
    public int points = 0;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = this;
        points = 0;
        pointsText.text = "x " + points;
        isGameActive = false;
        gameOverScreen.SetActive(false);
        titleScreen.SetActive(true);
        //audioSource.
        Debug.Log(music[0].name);
        audioSource.clip = music[0];
        audioSource.Play();
    }

    public void AddPoints(int numPoints)
    {
        points += numPoints;
        pointsText.text = "x " + points;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isGameActive)
        {
            lives = 3;
            audioSource.Stop();
            isGameActive = true;
            titleScreen.SetActive(false);
            gameOverScreen.SetActive(false);
            audioSource.clip = music[1];
            audioSource.Play();
        }
        if(Input.GetKeyDown(KeyCode.Backspace))
        {
            lives--;
        }
        if(lives <= 0 && isGameActive)
        {
            audioSource.Stop();
            isGameActive = false;
            gameOverScreen.SetActive(true);
            audioSource.clip = music[2];
            audioSource.Play();
        }
    }
}
