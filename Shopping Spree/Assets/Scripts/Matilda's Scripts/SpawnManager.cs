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
        GameObject ene = Instantiate(enemyPrefab, new Vector2(2.5f, Random.Range(-1,1)), enemyPrefab.transform.rotation);
        GameObject item = ene.transform.GetChild(1).GetComponent<ThoughtBubble>().pickedItem();
        ene.GetComponent<CustomerControl>().wantItem = item;
        Vector2 pos = new Vector2(Random.Range(-1.84f, 2.6f), Random.Range(-1.2f, 1.2f));
        Instantiate(item, pos, enemyPrefab.transform.rotation);
    }
    private Vector2 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosY = Random.Range(-spawnRange, spawnRange);

        Vector2 randomPos = new Vector2(spawnPosX, spawnPosY);
        return randomPos;
    }

}
