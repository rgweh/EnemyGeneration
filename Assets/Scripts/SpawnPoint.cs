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
            createFunc: () => CreateEnemy(),
            actionOnGet: (enemy) => OnGetEnemy(enemy),
            actionOnRelease: (enemy) => { },
            actionOnDestroy: (enemy) => Destroy(enemy.gameObject));
    }

    public Enemy SpawnEnemy()
    {
        return _enemyPool.Get();
    }

    private Enemy CreateEnemy()
    {
        var enemy = Instantiate(_enemy);
        enemy.transform.position = transform.position;
        enemy.SetTarget(_target);

        return enemy;
    }

    private Enemy OnGetEnemy(Enemy enemy)
    {
        enemy.transform.position = transform.position;
        return enemy;
    }
}
