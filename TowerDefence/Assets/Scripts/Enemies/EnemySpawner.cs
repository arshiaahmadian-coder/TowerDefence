using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform spawnPoint;
    public int currentWave = 0;
    public int maxWaves = 2;

    public List<Wave> waves = new List<Wave>();

    private void Start()
    {
        maxWaves = waves.Count;
        StartCoroutine(WaveSpawner());
    }

    IEnumerator WaveSpawner()
    {
        foreach(Wave wave in waves)
        {
            currentWave += 1;
            yield return new WaitForSeconds(wave.startDelay);
            foreach(MiniWave miniWave in wave.miniWaves)
            {
                yield return new WaitForSeconds(miniWave.spawnDelay);
                for(int i = 1; i <= miniWave.spawnNumber; i++)
                {
                    Instantiate(miniWave.enemyPrefab, spawnPoint.position, Quaternion.identity);
                    yield return new WaitForSeconds(miniWave.spawnInterval);
                }
            }
        }
    }
}

[Serializable]
public class Wave
{
    public List<MiniWave> miniWaves;
    public float startDelay;
}

[Serializable]
public class MiniWave
{
    public GameObject enemyPrefab;
    public int spawnNumber;
    public float spawnDelay;
    public float spawnInterval;
}
