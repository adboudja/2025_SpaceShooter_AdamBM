using System.Collections;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] enemyPrefab;

    public enum SpawnMode{
        line,
        points,
    }
    [SerializeField] SpawnMode spawnMode;
    [SerializeField] Transform spawn;
    
    private int enemyCount=1000;
    [SerializeField] float spawnRate;

    [SerializeField] Transform[] spawnPoints;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int randomEnemy = Random.Range(0, enemyPrefab.Length);
        if (spawnMode == SpawnMode.line)
        {
            StartCoroutine(LineSpawning());
        }
        else if (spawnMode == SpawnMode.points)
        {
            int numPoints = spawnPoints.Length;
            int j = Random.Range(0,numPoints);

            Vector3 startPosition = spawnPoints[j].position;

            Instantiate(enemyPrefab[randomEnemy], startPosition, Quaternion.identity);
        }
    }

    IEnumerator LineSpawning()
    {
        

        for (int i = 0; i < enemyCount; i++)
        {
            int randomEnemy = Random.Range(0, enemyPrefab.Length);
            float t = Random.Range(0f, 1f);
            Vector3 startPosition = spawn.position;

            Instantiate(enemyPrefab[randomEnemy], startPosition, enemyPrefab[randomEnemy].transform.rotation);

            yield return new WaitForSeconds(spawnRate);
        }


    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
