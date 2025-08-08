using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEditor;

public class SpawnerHandler : MonoBehaviour
{
    [SerializeField] private Enemy _baseEnemy;

    private List<Spawner> _spawners = new();
    private int _spawnersCount = 0;
    private float _spawnTime = 2f;
    private bool _isSpawning = false;
   

    private void Awake()
    {
        if (transform.childCount > 0)
        {

            for (int i = 0; i < transform.childCount; i++)
            {
                var child = transform.GetChild(i);
                if(child.TryGetComponent(out Spawner spawner))
                {
                    _spawners.Add(spawner); 
                    _spawnersCount++;
                }
            }

            _isSpawning = true;
            StartCoroutine(SpawnEnemies());
        }
    }

    private IEnumerator SpawnEnemies()
    {
        var wait = new WaitForSeconds(_spawnTime);

        while (_isSpawning)
        {
            int spawnerIndex = Random.Range(0, _spawnersCount);
            _spawners[spawnerIndex].SpawnEnemy(_baseEnemy);

            yield return wait;
        }

        yield return null;
    }
}