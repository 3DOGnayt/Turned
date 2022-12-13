using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private ObjectPooler.ObjectInfo.ObjectType _bulletType;
    [SerializeField] private Vector3 _spawnPosition;

    private void Update()
    {
        var bullet = ObjectPooler.Instance.GetObject(_bulletType);
        bullet.GetComponent<BulletP>().OnCreate(_spawnPosition, transform.rotation);
    }
}