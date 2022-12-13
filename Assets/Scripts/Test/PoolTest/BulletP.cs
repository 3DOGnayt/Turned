using UnityEngine;

public class BulletP : MonoBehaviour, IPooledObject
{
    public ObjectPooler.ObjectInfo.ObjectType Type => type;

    [SerializeField] private ObjectPooler.ObjectInfo.ObjectType type;

    private float _lifeTime = 1;
    private float _currentLifeTime;
    private float _speed = 10;

    public void OnCreate(Vector3 position, Quaternion rotation)
    {
        transform.position = position;
        transform.rotation = rotation;
        _currentLifeTime = _lifeTime;   
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * _speed);

        if ((_currentLifeTime -= Time.deltaTime) < 0)
            ObjectPooler.Instance.DestroyObject(gameObject);        
    }
}
