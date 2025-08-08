using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Vector3 _initialDirection;

    public void SpawnEnemy(Enemy enemy)
    {
        var newEnemy = Instantiate(enemy);
        newEnemy.transform.position = transform.position;
        newEnemy.TakeMovementDirection(_initialDirection);
    }
}
