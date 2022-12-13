using UnityEngine;

public class SpawnerTest : MonoBehaviour
{
    [SerializeField] private GameObject _enemy = null;
    [SerializeField] private int _enemyNum = 7;

    private int _currentenemyNum = 0;
    
    void Start()
    {
        InvokeRepeating("CreateEnemy", 2, 3);
        InvokeRepeating("CreateEnemy1", 2, 2);
        InvokeRepeating("CreateEnemy2", 2, 1);
    }


    private void CreateEnemy()
    {
        Vector3 a = new Vector3(-6, 24, 0);        
        var instantiate = Instantiate(_enemy, a, Quaternion.identity);
        _currentenemyNum++;
        if (_currentenemyNum >= _enemyNum)
            CancelInvoke("CreateEnemy");
    }

    private void CreateEnemy1()
    {
        Vector3 b = new Vector3(0, 14, 0);
        var instantiate = Instantiate(_enemy, b, Quaternion.identity);
        _currentenemyNum++;
        if (_currentenemyNum >= _enemyNum)
            CancelInvoke("CreateEnemy1");
    }

    private void CreateEnemy2()
    {
        Vector3 c = new Vector3(6, 36, 0);
        var instantiate = Instantiate(_enemy, c, Quaternion.identity);
        _currentenemyNum++;
        if (_currentenemyNum >= _enemyNum)
            CancelInvoke("CreateEnemy2");
    }
}