using UnityEngine;

public class BulletEx : MonoBehaviour
{
    [SerializeField] private float _speed = 0.8f;
    [SerializeField] private int _damage = 1;

    private void Update()
    {
        transform.Rotate(new Vector3(0f, 0f, -180f * (_speed * Time.deltaTime)));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<ITakeDamage>(out var enemy))
        {
            enemy.TakeDamage(_damage);
        }
    }
}