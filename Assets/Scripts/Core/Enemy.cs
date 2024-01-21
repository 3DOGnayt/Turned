using Assets.Scripts.Interfaces;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Core
{
    public class Enemy : MonoBehaviour, IReturnToPool, ITakeDamage
    {
        [SerializeField] private Enemy _enemy;
        [SerializeField] private int _hp = 1;
        [SerializeField] private int _damage = 1;
        [SerializeField] private int _speed = 1;
        [SerializeField] private int _time = 4;

        public void EnemyPosition(Vector3 position)
        {
            gameObject.transform.position = position;
            StartCoroutine(Fall(_speed, _time));
        }

        private IEnumerator Fall(int speed, int time)
        {
            for (float i = 0; i < time;)
            {
                i += Time.deltaTime;
                transform.Translate(Vector3.down * _speed * Time.deltaTime);
                yield return null;
            }
            _enemy.ReturnToPool();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<ITakeDamage>(out var item))
            {
                item.TakeDamage(_damage);
            }
        }

        public void ReturnToPool()
        {
            gameObject.SetActive(false);
        }

        public void TakeDamage(int damage)
        {
            _hp -= damage;
            ReturnToPool();
        }
    }
}