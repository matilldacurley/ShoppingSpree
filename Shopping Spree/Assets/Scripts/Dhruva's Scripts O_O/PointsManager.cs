using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsManager : MonoBehaviour
{
    public static PointsManager pointsManager;
    public int points = 0;

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] controllers = GameObject.FindGameObjectsWithTag("GameController");
        if (controllers.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
        pointsManager = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
