using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Vector3 _movementDirection;

    private void Update()
    {
        Move();
    }

    public void TakeMovementDirection(Vector3 movementDirection)
    {
        _movementDirection = movementDirection;
    }

    private void Move()
    {
        transform.position += _movementDirection;
    }
}
