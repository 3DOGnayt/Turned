using Assets.Scripts.Core;
using UnityEngine;

namespace Assets.Scripts.Pool
{
    public class PoolEmenyView : MonoBehaviour
    {
        [SerializeField] private PoolEnemy _poolEnemy;
        [Space(20)]
        [SerializeField] private Spawner _spawner;
        [SerializeField] private Vector3 _spawnPosition;
        [Space(20)]
        [SerializeField] private float _startSpawn;
        [SerializeField] private float _repeatSpawn;
        [SerializeField] private int _enemyCount;

        public PoolEnemy PoolEnemy => _poolEnemy;
        public int EnemyCount => _enemyCount;

        private int _random;
        
        private void Awake()
        {
            _poolEnemy.EnemyList = _spawner.Enemy;
            _spawnPosition = _spawner.SpawnPosition;
            _startSpawn = _spawner.StartSpawn;
            _repeatSpawn = _spawner.RepeatSpawn;

            _enemyCount = (int)_spawner.EnemyCount;

            _poolEnemy.CreatePool();            
        }

        private void Update()
        {
            SpawnEnemy();
        }

        private void SpawnEnemy()
        {
            if (_enemyCount <= 0) return;

            _repeatSpawn -= Time.deltaTime;

            if (_repeatSpawn <= 0)
            {
                _random = Random.Range(0, _poolEnemy.EnemyList.Count);
                Vector3 position = Vector3.zero + new Vector3(Random.Range(-_spawnPosition.x, _spawnPosition.x), _spawnPosition.y, 0);
                _poolEnemy.GetFreeElement(_random).EnemyPosition(position);
                _repeatSpawn = _startSpawn;
                _enemyCount -= 1;
            }
        }
    }
}