using System.Collections.Generic;

public static class AssetPath
{
    public static readonly Dictionary<EnemyType, string> Enemies = new Dictionary<EnemyType, string>
        {
            {EnemyType.Small, "Prefabs/Enemies/Enemy"}
        };
}