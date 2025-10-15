using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Renderer))]
public class Target : MonoBehaviour
{
    [SerializeField] private Vector3 _startPoint;
    [SerializeField] private Vector3 _endPoint;
    [SerializeField] private List<Vector3> _targets;
    [SerializeField] private float _speed;

    private int _targetIndex = 0;
    private float _distanceMargin = 0.1f;
    private Vector3 _currentTarget;
    private Renderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        _renderer.material.color = Random.ColorHSV();
        transform.position = _targets[_targetIndex];
        SwitchTarget();
    }

    private void Update()
    {
        if (Vector3.SqrMagnitude(_currentTarget - transform.position) <= _distanceMargin)
            SwitchTarget();

        MoveToPoint(_currentTarget);
    }

    private void MoveToPoint(Vector3 point)
    {
        transform.position = Vector3.MoveTowards(transform.position, point, _speed * Time.deltaTime);
    }

    private void SwitchTarget()
    {
        _currentTarget = _targets[++_targetIndex % _targets.Count];
    }
}
