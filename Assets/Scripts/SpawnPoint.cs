using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private Target _target;
    [SerializeField] private Enemy _enemy;
    
    public Enemy Enemy => _enemy;

    public void SetUpEnemy(Enemy enemy)
    {
        enemy.transform.position = transform.position;
        enemy.SetTarget(_target);
    }
}
