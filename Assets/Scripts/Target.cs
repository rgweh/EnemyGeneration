using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Renderer))]
public class Target : MonoBehaviour
{
    [SerializeField] private List<Vector3> _targets;
    [SerializeField] private float _speed;

    private float _distanceMargin = 0.1f;
    private int _targetIndex = 0;
    private Vector3 _currentTarget;
    private Renderer _renderer;

    private void OnEnable()
    {
        _renderer = GetComponent<Renderer>();
        _renderer.material.color = Random.ColorHSV();
        transform.position = _targets[_targetIndex];
        _currentTarget = _targets[++_targetIndex];
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
        _targetIndex = ++_targetIndex % _targets.Count;
        _currentTarget = _targets[_targetIndex];
    }
}
