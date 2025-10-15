using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected Target Target;
    protected float Speed = 2f;

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, Target.transform.position, Speed * Time.deltaTime);
    }

    public void SetTarget(Target target)
    {
        Target = target;
    }
}
