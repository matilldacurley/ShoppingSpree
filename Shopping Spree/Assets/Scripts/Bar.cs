using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{
    public GameObject fill;
    public float max_time = 15.0f;
    public float time_remaining;
    public Vector2 startSize;
    public int maxValue;
    [Range(0.1f,10)]
    public float currentValue;

    // Start is called before the first frame update
    void Start()
    {
        time_remaining = max_time;
    }

    // Update is called once per frame
    void Update()
    {
        //max_time += timePerWave * (SpawnManager.spawnManager.waveNumber - 1);

        float size;
        if (time_remaining > 0)
        { 
            time_remaining -= Time.deltaTime;
            size = (startSize.y / (float)max_time) * (float)time_remaining;

            fill.transform.localScale = new Vector2(startSize.x, size);
        }

        if (time_remaining < max_time * 0.66)
        {
            fill.GetComponent<SpriteRenderer>().color = Color.yellow;
        }

        if (time_remaining < max_time * 0.33)
        {
            fill.GetComponent<SpriteRenderer>().color = Color.red;
        }
        /*
        if(time_remaining <= 0)
        {
            GameManager.gameManager.LoseLives();
        }
        */
    }
}
