using UnityEngine;

public class Floor : MonoBehaviour, ITakeDamage
{    
    [SerializeField] private int _hp = 10;

    private int _damage = 1;
    private void Update()
    {
        if (_hp == 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<ITakeDamage>(out var takeDamage))
        {
            takeDamage.TakeDamage(_damage);
            _hp -= _damage;
        }
    }

    public void TakeDamage(int damage)
    {
        _hp -= damage;
    }
}