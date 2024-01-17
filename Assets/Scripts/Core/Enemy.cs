using UnityEngine;

public class Enemy : MonoBehaviour, ITakeDamage
{
    [SerializeField] private int _hp = 1;
    [SerializeField] private int _damage = 1;

    private void Update()
    {
        if (_hp <= 0)  // fix, do pool
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<ITakeDamage>(out var enemy))
        {
            enemy.TakeDamage(_damage);
        }
    }

    public void TakeDamage(int damage)
    {
        _hp -= damage;
    }
}