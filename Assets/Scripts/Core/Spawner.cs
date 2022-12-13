using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] _enemy;

    private int _random;
    public float _startSpawn;
    private float _repeatSpawn;
    public Vector3 _size;

    private void Start()
    {
        _repeatSpawn = _startSpawn;
    }

    private void Update()
    {
        if (_repeatSpawn <= 0)
        {
            Vector3 pos = Vector3.zero + new Vector3(Random.Range(-_size.x, _size.x), 14, 0);
            _random = Random.Range(0, _enemy.Length);
            Instantiate(_enemy[_random], pos, Quaternion.identity);
            _repeatSpawn = _startSpawn;
        }
        else
        {
            _repeatSpawn -= Time.deltaTime;
        }
    }
}