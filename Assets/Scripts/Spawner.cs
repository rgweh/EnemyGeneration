using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<SpawnPoint> _spawnPoints;

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
        _spawnPoints = new List<SpawnPoint>();

        for (int i = 0; i < transform.childCount; i++)
        {
            var child = transform.GetChild(i);

            if (child.TryGetComponent(out SpawnPoint spawner))
            {
                _spawnPoints.Add(spawner);
            }
        }
    }
#endif

    private IEnumerator SpawnEnemies()
    {
        var wait = new WaitForSeconds(_spawnTime);

        while (_isSpawning)
        {
            var spawnPoint = _spawnPoints[Random.Range(0, _spawnPoints.Count)];
            spawnPoint.SetUpEnemy(Instantiate(spawnPoint.Enemy));

            yield return wait;
        }
    }
}