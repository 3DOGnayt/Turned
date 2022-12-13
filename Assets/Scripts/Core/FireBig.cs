using UnityEngine;

public class FireBig : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform[] _massiv;
    [SerializeField] private float _timeToDestroy = 2;

    private bool _fire = false;

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
            _fire = true;
    }

    private void FixedUpdate()
    {
        if (_fire)
            BigSword();
    }    

    public void BigSword()
    {
        for (int i = 0; i < _massiv.Length; i++)
        {
            Destroy(Instantiate(_bullet, _massiv[i].position, Quaternion.AngleAxis(90, Vector3.forward)), _timeToDestroy);
        }
        _fire = false;
    }
}