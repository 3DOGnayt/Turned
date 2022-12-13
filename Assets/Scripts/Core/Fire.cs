using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform[] _massiv;
    [SerializeField] private float _timeToDestroy = 2;
    
    private bool _fire = false;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            _fire = true;
    }

    private void FixedUpdate()
    {
        if (_fire)
            FireSword();
    }    

    public void FireSword()
    {
        for (int i = 0; i < _massiv.Length; i++)
        {
            Destroy(Instantiate(_bullet, _massiv[i].position, Quaternion.identity), _timeToDestroy);            
        }
        _fire = false;
    }
}