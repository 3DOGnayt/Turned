using UnityEngine;

public class Enemy : MonoBehaviour, ITakeDamage, ICreate
{
    [SerializeField] private GameObject _enemy;
    [SerializeField] private int _hp = 1;

    public int Hp { get; }
    public Vector3 Position { get; }

    public Enemy(int hp, Vector3 position)
    {
        Hp = hp;
        Position = position;
    }

    private void Update()
    {
        if (_hp <= 0)
        {
            Destroy(gameObject);
        }
    }    

    public void TakeDamage(int damage)
    {
        _hp -= damage;
    }
}