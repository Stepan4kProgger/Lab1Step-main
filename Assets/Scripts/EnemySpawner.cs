using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemySpawner : ObjectPool
{
    [SerializeField] private float _spawnDelay;
    [SerializeField] private SpawnPoint[] _spawnPoints;
    
    private void Awake()
    {
        Initialize();
    }

    private void Start()
    {
        StartCoroutine(Spawn());
    }
    

    private IEnumerator Spawn()
    {
        while (true)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(_spawnDelay);
        }
    }

    private void SpawnEnemy()
    {
        if (TryGetElement(out GameObject poolObject))
        {
            poolObject.SetActive(true);
            Enemy enemy = poolObject.GetComponent<Enemy>();
            enemy.Spawn(_spawnPoints[Random.Range(0, _spawnPoints.Length)].transform.position);
        }
    }
    
}