using UnityEngine;

internal sealed class EnemyFactory : ICreateFactory
{
    public ICreate CreateEnemy(int hp, Vector3 position)
    {
        return new Enemy(hp, position);
    }
}