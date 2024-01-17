using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 60;
    [SerializeField] private int _damage = 1;

    private void Update()
    {
        transform.Translate(Vector3.up * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<ITakeDamage>(out var enemy))
        {
            enemy.TakeDamage(_damage);
        }
    }
}