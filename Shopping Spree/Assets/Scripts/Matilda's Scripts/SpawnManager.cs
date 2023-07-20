using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnRange = 9;
    public int enemyCount;
    public int waveNumber = 1;
    public Transform spawnPos;

    
    // Start is called before the first frame update
    void Start()
    {

        SpawnEnemyWave(waveNumber);   
    }

    void SpawnEnemyWave(int num)
    {
        for(int i = 0; i < num; i++)
        {       
            SpawnEnemy();
        }
   
    }

    // Update is called once per frame
    

    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        //print(enemyCount);
        if (enemyCount == 0)
        {         
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            
        }
    }

    private void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPos.position, enemyPrefab.transform.rotation);
    }
    private Vector2 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosY = Random.Range(-spawnRange, spawnRange);

        Vector2 randomPos = new Vector2(spawnPosX, spawnPosY);
        return randomPos;
    }

}