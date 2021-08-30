using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 60;
    private int _damage = 1;

    public void Init(int damage, Transform target)
    {
        _damage = damage;
        ReturnToPool();
        //Destroy(gameObject, 10);
    }

    private void Update()
    {
        transform.Translate(Vector3.up * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<ITakeDamage>().TakeDamage(_damage);
        }
        ReturnToPool();
    }

    public void ReturnToPool()
	{
		gameObject.SetActive(false);
	}
}
