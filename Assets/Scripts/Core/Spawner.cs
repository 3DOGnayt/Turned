using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _enemy;
    [SerializeField] private float _spawnZoneLeft;
    [SerializeField] private float _spawnZoneRight;
    [SerializeField] private float _spawnZoneHight;
    [Space]
    [SerializeField] private float _startSpawn;
    [SerializeField] private float _repeatSpawn;

    private int _random;

    private void Start()
    {
        _repeatSpawn = _startSpawn;
    }

    private void Update()
    {
        _repeatSpawn -= Time.deltaTime;

        if (_repeatSpawn <= 0)
        {
            Vector3 pos = Vector3.zero + new Vector3(Random.Range(-_spawnZoneLeft, _spawnZoneRight), _spawnZoneHight, 0);
            _random = Random.Range(0, _enemy.Length);
            Instantiate(_enemy[_random], pos, Quaternion.identity);
            _repeatSpawn = _startSpawn;
        }
    }
}