using Assets.Scripts.Interfaces;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Core.Skills
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private Bullet _bullet;
        [SerializeField] private float _speed = 60;
        [SerializeField] private int _damage = 1;
        [SerializeField] private int _lifeTime = 2;

        public float Speed => _speed;

        public void SmallBullet(Transform transform)
        {
            gameObject.transform.position = transform.position;
            StartCoroutine(Fire(_lifeTime));
        }

        private IEnumerator Fire(int time)
        {
            for (float i = 0; i < time;)
            {
                i += Time.deltaTime;
                transform.Translate(Vector3.up * _speed * Time.deltaTime);
                yield return null;
            }

            _bullet.ReturnToPool();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<ITakeDamage>(out var enemy))
            {
                enemy.TakeDamage(_damage);
            }
        }

        public void ReturnToPool()
        {
            gameObject.SetActive(false);
        }
    }
}