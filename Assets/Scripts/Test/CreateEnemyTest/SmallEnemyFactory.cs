using UnityEngine;

public sealed class SmallEnemyFactory : ICreatorEnemy
{
    public Enemy2 Create(Hp hp)
    {
        var enemy = Object.Instantiate(Resources.Load<SmallEnemy>(AssetPath.Enemies[EnemyType.Small]));

        enemy.SetHP(hp);

        return enemy;
    }
}