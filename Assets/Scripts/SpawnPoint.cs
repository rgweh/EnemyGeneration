using UnityEngine;
using UnityEngine.Pool;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private Target _target;
    [SerializeField] private Enemy _enemy;
    [SerializeField] private ObjectPool<Enemy> _enemyPool;

    public void Awake()
    {
        _enemyPool = new ObjectPool<Enemy>(
            createFunc: () => CreateEnemy()
            );
    }

    public Enemy CreateEnemy()
    {
        _enemy.transform.position = transform.position;
        _enemy.SetTarget(_target);
        return Instantiate(_enemy);
    }
}
