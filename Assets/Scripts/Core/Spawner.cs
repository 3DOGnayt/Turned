using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Core
{
    [CreateAssetMenu(fileName = "SpawnEnemySettings", menuName = "Settings/EnemySpawn")]
    public class Spawner : ScriptableObject
    {
        [SerializeField] private List<Enemy> _enemy;
        [SerializeField] private Vector3 _spawnPosition;
        [Space]
        [SerializeField] private float _startSpawn;
        [SerializeField] private float _repeatSpawn;

        public List<Enemy> Enemy => _enemy;
        public Vector3 SpawnPosition => _spawnPosition;
        public float StartSpawn => _startSpawn;
        public float RepeatSpawn => _repeatSpawn;
    }
}