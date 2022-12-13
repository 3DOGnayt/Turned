using UnityEngine;

internal class JumpTransform : IJump
{
    private readonly Transform _transform;
    private Vector3 _jump;

    public float Speed { get; protected set; }

    public JumpTransform(Transform transform, float speed)
    {
        _transform = transform;
        Speed = speed;
    }

    public void Jump(float vertical, float deltaTime)
    {
        var speed = deltaTime * Speed;
        _jump.Set(0.0f, vertical * speed, 0.0f);
        _transform.localPosition += _jump;
    }
}