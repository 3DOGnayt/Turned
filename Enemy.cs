using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, ITakeDamage
{
    [SerializeField] private GameObject _enemy = null;
    [SerializeField] private int _hp = 1;

    private void Update()
    {
        if (_hp == 0)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        _hp -= damage;
    }



}
