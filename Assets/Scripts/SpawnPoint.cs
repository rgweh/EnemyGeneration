using UnityEngine;
using UnityEngine.Pool;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private Target _target;
    [SerializeField] private Enemy _enemy;

    public Enemy CreateEnemy()
    {
        var enemy = Instantiate(_enemy);
        enemy.transform.position = transform.position;
        enemy.SetTarget(_target);

        return enemy;
    }
}
