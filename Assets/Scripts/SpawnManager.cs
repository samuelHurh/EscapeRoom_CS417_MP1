using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour
{
    public List<EnemySpawner> enemySpawners = new List<EnemySpawner>();
    public List<EnemySpawner> spawnsChosenThisCycle = new List<EnemySpawner>();
    private System.Random rng = new System.Random();
    public float startingSpawnInterval;
    private float currSpawnInterval;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ReShuffle();
        StartCoroutine(SpawnLoop());
        currSpawnInterval = startingSpawnInterval;
    }

    public void ReShuffle()
    {
        spawnsChosenThisCycle = new List<EnemySpawner>(enemySpawners);
        for (int i = spawnsChosenThisCycle.Count - 1; i > 0; i--)
        {
            int j = rng.Next(i + 1);
            (spawnsChosenThisCycle[i], spawnsChosenThisCycle[j]) = (spawnsChosenThisCycle[j], spawnsChosenThisCycle[i]);
        }
    }

    public void UpdateSpawnInterval()
    {
        currSpawnInterval -= 2f;
    }

    public IEnumerator SpawnLoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(currSpawnInterval);
            if (spawnsChosenThisCycle.Count == 0)
                ReShuffle();

            int lastIndex = spawnsChosenThisCycle.Count - 1;
            var selectedSpawner = spawnsChosenThisCycle[lastIndex];
            spawnsChosenThisCycle.RemoveAt(lastIndex);
            selectedSpawner.SpawnEnemy();
        }
    }
}
