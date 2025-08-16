using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEditor;
using Unity.VisualScripting;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy _baseEnemy;
    [SerializeField] private List<SpawnPoint> _spawners;

    private int _spawnersCount;
    private float _spawnTime = 2f;
    private bool _isSpawning = false;

    private void Awake()
    {
        if (transform.childCount > 0)
        {
            _isSpawning = true;
            StartCoroutine(SpawnEnemies());
        }
    }

#if UNITY_EDITOR
    [ContextMenu("Refresh Child Array")]
    private void RefreshChildArray()
    {
        _spawners = new List<SpawnPoint>();
        _spawnersCount = 0;

        for (int i = 0; i < transform.childCount; i++)
        {
            var child = transform.GetChild(i);

            if (child.TryGetComponent(out SpawnPoint spawner))
            {
                _spawners.Add(spawner);
                _spawnersCount++;
            }
        }
    }
#endif

    private IEnumerator SpawnEnemies()
    {
        var wait = new WaitForSeconds(_spawnTime);

        while (_isSpawning)
        {
            int spawnerIndex = Random.Range(0, _spawnersCount);
            _spawners[spawnerIndex].SpawnEnemy(Instantiate(_baseEnemy));

            yield return wait;
        }

        yield return null;
    }
}