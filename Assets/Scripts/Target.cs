using UnityEngine;

[RequireComponent (typeof(Renderer))]
public class Target : MonoBehaviour
{
    [SerializeField] private Vector3 _startPoint;
    [SerializeField] private Vector3 _endPoint;
    [SerializeField] private float _speed;
    [SerializeField] private Vector3 _currentTarget;

    private Renderer _renderer;

    private void OnEnable()
    {
        _renderer = GetComponent<Renderer>();
        _renderer.material.color = Random.ColorHSV();
        transform.position = _startPoint;
        _currentTarget = _endPoint;
    }

    private void Update()
    {
        if (Vector3.Distance(_currentTarget, transform.position) <= 0.1f)
            SwitchTarget();

        MoveSelfToPoint(_currentTarget);
    }

    private void MoveSelfToPoint(Vector3 point)
    {
        transform.position = Vector3.MoveTowards(transform.position, point, _speed * Time.deltaTime);
    }

    private void SwitchTarget()
    {
        if (_currentTarget == _endPoint)
            _currentTarget = _startPoint;
        else
            _currentTarget = _endPoint;
        
    }
}
