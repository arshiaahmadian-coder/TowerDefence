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
    public List<BaseEnemy> enemies = new List<BaseEnemy>();

    public static EnemySpawner instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        maxWaves = waves.Count;
        StartCoroutine(WaveSpawner());
    }

    public void AddEnemyToList(BaseEnemy enemy)
    {
        enemies.Add(enemy);
    }

    public void RemoveEnemyFromList(BaseEnemy enemy)
    {
        enemies.Remove(enemy);
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
                    GameObject newEnemy = Instantiate(miniWave.enemyPrefab, 
                        spawnPoint.position, Quaternion.identity);
                    // add enemy to list 
                    AddEnemyToList(newEnemy.GetComponent<BaseEnemy>());

                    yield return new WaitForSeconds(miniWave.spawnInterval);
                }
            }
        }
    }

    public BaseEnemy FindTarget(Transform searchPos, float searchRange)
    {
        float closestEnemyDistance = float.MaxValue;
        BaseEnemy closestEnemy = null;
        foreach(BaseEnemy enemy in enemies)
        {
            // its in tower range
            if (Vector3.Distance(searchPos.position, enemy.transform.position) <= searchRange)
            {
                // distance between enemy and his next waypoint
                float distance = Vector3.Distance(enemy.transform.position, 
                    WaypointManager.instance.waypoints[enemy.currentWaypoint].transform.position);

                if (distance < closestEnemyDistance)
                {
                    closestEnemy = enemy;
                    closestEnemyDistance = distance;
                }
            }
        }
        return closestEnemy;
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
