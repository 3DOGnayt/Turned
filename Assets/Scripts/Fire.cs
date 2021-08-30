using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _transform;

    public void FireSword()
    {
        var bullet = GameObject.Instantiate(_bullet, _transform.position, Quaternion.identity).GetComponent<Bullet>();
    }
}
