using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    public bool isGameActive = false;
    public bool inLevel2 = false;
    public int lives = 3;
    public GameObject titleScreen;
    public GameObject gameOverScreen;
    public GameObject endScreen;
    public AudioClip[] music;
    public AudioSource audioSource;
    public TextMeshProUGUI pointsText;
    public TextMeshProUGUI livesText;
    public int points = 0;

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] controllers = GameObject.FindGameObjectsWithTag("GameController");
        if(controllers.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
        gameManager = this;
        pointsText.text = "x " + points;
        isGameActive = false;
        gameOverScreen.SetActive(false);
        endScreen.SetActive(false);
        titleScreen.SetActive(true);
        if(inLevel2)
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
        points += numPoints;
        pointsText.text = "x " + points;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isGameActive && !inLevel2)
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
        else if(Input.GetKeyDown(KeyCode.Space) && !isGameActive && inLevel2)
        {
            lives = 3;
            isGameActive = true;
            titleScreen.SetActive(false);
            gameOverScreen.SetActive(false);
            endScreen.SetActive(false);
        }
        if(lives <= 0 && isGameActive)
        {
            audioSource.Stop();
            isGameActive = false;
            gameOverScreen.SetActive(true);
            audioSource.clip = music[2];
            audioSource.Play();
        }
        if (points == 20)
        {
            isGameActive = false;
            endScreen.SetActive(true);
        }
        if (points == 10)
        {
            StartCoroutine(WaitAndLoad());
        }
    }

    public void LoseLives()
    {
        lives--;
        livesText.text = "x " + lives;
    }

    IEnumerator WaitAndLoad()
    {
        yield return new WaitForSeconds(1);
        audioSource.Stop();
        inLevel2 = true;
        SceneManager.LoadScene("Level2");
        audioSource.clip = music[3];
        audioSource.Play();
    }
}
