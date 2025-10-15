using UnityEngine;
using UnityEngine.Pool;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private Target _target;
    [SerializeField] private Enemy _enemy;

    private ObjectPool<Enemy> _enemyPool;

    private void Awake()
    {
        _enemyPool = new ObjectPool<Enemy>(
            createFunc: () => SetUpEnemy() );
    }

    public Enemy SetUpEnemy()
    {
        var enemy = Instantiate(_enemy);
        enemy.transform.position = transform.position;
        enemy.SetTarget(_target);

        return enemy;
    }
}
