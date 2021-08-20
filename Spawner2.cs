using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner2 : MonoBehaviour
{
    public GameObject[] _enemy;
    public Transform[] _transforms;

    private int _random;
    private int _randomPosition;
    public float _startSpawn;
    private float _betwenSpawn;

    private void Start()
    {
        _betwenSpawn = _startSpawn;
    }

    private void Update()
    {
        if (_betwenSpawn <= 0)
        {
            _random = Random.Range(0, _enemy.Length);
            _randomPosition = Random.Range(0, _transforms.Length);
            Instantiate(_enemy[_random], _transforms[_randomPosition].transform.position, Quaternion.identity);
            _betwenSpawn = _startSpawn;
        }
        else
        {
            _betwenSpawn -= Time.deltaTime;        
        }

    }

}
