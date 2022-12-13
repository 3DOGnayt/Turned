using UnityEngine;

internal class MoveTransform : IMove
{
    private readonly Transform _transform;
    private Vector3 _move;

    public float Speed { get; protected set; }

    public MoveTransform(Transform transform, float speed)
    {
        _transform = transform;
        Speed = speed;
    }

    public void Move(float horizontal, float deltaTime)
    {
        var speed = deltaTime * Speed;
        _move.Set(horizontal * speed, 0.0f, 0.0f);
        _transform.localPosition += _move;
    }
}