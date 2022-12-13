using UnityEngine;

public abstract class Enemy2 : MonoBehaviour
{
    public Hp Hp;
    public static ICreatorEnemy Factory = new SmallEnemyFactory();

    public static SmallEnemy CreateSmallEnemy(Hp hp)
    {
        var enemy = Instantiate(Resources.Load<SmallEnemy>(AssetPath.Enemies[EnemyType.Small]));

        enemy.Hp = hp;

        return enemy;
    }

    public void SetHP(Hp hp)
    {
        Hp = hp;
    }
}