using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private Vector3 _initialDirection;

    public void SpawnEnemy(Enemy enemy)
    {
        enemy.transform.position = transform.position;
        enemy.SetMovementDirection(_initialDirection);
    }
}
