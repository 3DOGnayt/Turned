using Assets.Scripts.Interfaces;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Skills
{
    public class BulletEx : MonoBehaviour
    {
        [SerializeField] private BulletEx _bullet;
        [SerializeField] private Transform rotation;
        [SerializeField] private float _speed = 0.8f;
        [SerializeField] private int _damage = 1;
        [SerializeField] private int _lifeTime = 1;

        public float Speed => _speed;

        public void ExBullet(Transform transform)
        {
            rotation.rotation = new Quaternion(0, 0, 0, 0);
            gameObject.transform.position = transform.position;
            StartCoroutine(Fire(_lifeTime));
        }

        private IEnumerator Fire(int time)
        {
            for (float i = 0; i < time;)
            {
                i += Time.deltaTime;
                transform.Rotate(new Vector3(0, 0, -180 * (_speed * Time.deltaTime)));
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