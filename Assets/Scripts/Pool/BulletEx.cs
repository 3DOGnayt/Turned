using UnityEngine;

public class BulletEx : MonoBehaviour
{
    [SerializeField] private float _speed = 0.8f;
    private int _damage = 1;

    public void Init(int damage, Transform target)
    {
        _damage = damage;
    }

    private void Update()
    {
        transform.Rotate(new Vector3(0f, 0f, -180f * (_speed * Time.deltaTime)));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<ITakeDamage>().TakeDamage(_damage);
        }
    }
}
