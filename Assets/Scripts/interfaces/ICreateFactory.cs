using UnityEngine;

internal interface ICreateFactory
{
    ICreate CreateEnemy(int hp, Vector3 position); 
}
