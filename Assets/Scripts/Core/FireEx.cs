using UnityEngine;

public class FireEx : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _spawn;
    [SerializeField] private float _timeToDestroy = 1;

    private bool _fire = false;    

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            _fire = true;
    }

    private void FixedUpdate()
    {
        if (_fire)
            ExSword();       
    }    

    public void ExSword()
    {   
        Destroy(Instantiate(_bullet, _spawn.position, _spawn.rotation), _timeToDestroy);
        _fire = false;
    }
}