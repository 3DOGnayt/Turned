using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform[] _bulletPosition;
    [SerializeField] private float _timeToDestroy = 2;
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            FireSword();
    }

    public void FireSword()
    {
        for (int i = 0; i < _bulletPosition.Length; i++)
        {
            Destroy(Instantiate(_bullet, _bulletPosition[i].position, Quaternion.identity), _timeToDestroy);  // fix, do pool
        }
    }
}