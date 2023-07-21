using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    public bool isGameActive = false;
    public bool GameOver = false;
    public bool inLevel2 = false;
    public int lives = 3;
    public GameObject titleScreen;
    public GameObject gameOverScreen;
    public GameObject endScreen;
    public AudioClip[] music;
    public AudioSource audioSource;
    public TextMeshProUGUI pointsText;
    public TextMeshProUGUI livesText;


    // Start is called before the first frame update
    void Start()
    {
        gameManager = this;
        pointsText.text = "x " + PointsManager.pointsManager.points;
        livesText.text = "x " + lives;
        isGameActive = false;
        gameOverScreen.SetActive(false);
        endScreen.SetActive(false);
        titleScreen.SetActive(true);
        if (inLevel2)
        {
            audioSource.clip = music[3];
            audioSource.Play();
        }
        else
        {
            audioSource.clip = music[0];
            audioSource.Play();
        }
    }


    public void AddPoints(int numPoints)
    {
        PointsManager.pointsManager.points += numPoints;
        pointsText.text = "x " + PointsManager.pointsManager.points;
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isGameActive && !inLevel2 && !GameOver)
        {
            lives = 3;
            audioSource.Stop();
            isGameActive = true;
            titleScreen.SetActive(false);
            gameOverScreen.SetActive(false);
            endScreen.SetActive(false);
            audioSource.clip = music[1];
            audioSource.Play();
        }
        else if (Input.GetKeyDown(KeyCode.Space) && !isGameActive && inLevel2 && !GameOver)
        {
            lives = 3;
            isGameActive = true;
            titleScreen.SetActive(false);
            gameOverScreen.SetActive(false);
            endScreen.SetActive(false);
        }
        else if(Input.GetKeyDown(KeyCode.Space) && !isGameActive && inLevel2 && GameOver)
        {
            SceneManager.LoadScene("Level1");
            titleScreen.SetActive(true);
            gameOverScreen.SetActive(false);
            endScreen.SetActive(false);
            inLevel2 = false;
            isGameActive = false;
            GameOver = false;
            PointsManager.pointsManager.points = 0;
            lives = 3;
            pointsText.text = "x " + PointsManager.pointsManager.points;
            livesText.text = "x " + lives;
        }

        if (lives <= 0 && isGameActive)
        {
            audioSource.Stop();
            isGameActive = false;
            gameOverScreen.SetActive(true);
            audioSource.clip = music[2];
            audioSource.Play();
        }
        if (PointsManager.pointsManager.points == 19)
        {
            AddPoints(1);
            audioSource.Stop();
            isGameActive = false;
            GameOver = true;
            endScreen.SetActive(true);
            audioSource.clip = music[1];
            audioSource.Play();
        }
        if (PointsManager.pointsManager.points == 9)
        {
            SceneManager.LoadScene("Level2");
            AddPoints(1);
            audioSource.Stop();
            inLevel2 = true;
            isGameActive = false;
        }
    }

    public void LoseLives()
    {
        lives--;
        livesText.text = "x " + lives;
    }

}
