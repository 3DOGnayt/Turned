using Assets.Scripts.Core;
using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Assets.Scripts.Pool
{
    [Serializable]
    public class PoolEnemy
    {
        [SerializeField] private List<Enemy> _enemyListPrefab;
        [SerializeField] private List<Enemy> _listElements;
        [SerializeField] private GameObject _poolEnemyView;
        [SerializeField] private int _minValue;
        [SerializeField] private int _maxValue;
        [SerializeField] private bool _breakLimitPool;

        public List<Enemy> EnemyList { get => _enemyListPrefab; set => _enemyListPrefab = value; }
        public int MinValue => _minValue;

        private List<GameObject> _listContainers;
        private GameObject _pool;

        public void LimitCheck()
        {
            if (!_breakLimitPool)
                return;
            else _maxValue = int.MaxValue;
        }

        public void CreatePool()
        {
            _listElements = new List<Enemy>(_minValue);
            _listContainers = new List<GameObject>(_enemyListPrefab.Count);

            foreach (var enemyType in _enemyListPrefab)
            {
                _pool = new GameObject();
                var container = Object.Instantiate(_pool, _poolEnemyView.transform);
                container.name = "ContainerEnemy";
                _listContainers.Add(container);
                Object.Destroy(_pool);
            }

            for (int i = 0; i < _enemyListPrefab.Count; i++)
            {
                for (int k = 0; k < _minValue; k++)
                {
                    CreateElement(i);
                }
            }
        }

        public Enemy CreateElement(int typeEnemy, bool isActive = false)
        {
            var element = Object.Instantiate(_enemyListPrefab[typeEnemy], _listContainers[typeEnemy].transform);
            element.gameObject.SetActive(isActive);

            _listElements.Add(element);

            return element;
        }

        private bool TryGetElement(out Enemy poolObject)
        {
            foreach (var item in _listElements)
            {
                if (!item.gameObject.activeInHierarchy)
                {
                    poolObject = item;
                    item.gameObject.SetActive(true);
                    return true;
                }
            }

            poolObject = null;
            return false;
        }

        public Enemy GetFreeElement(int randomEnemy)
        {
            if (TryGetElement(out var elenemt))
            {
                return elenemt;
            }

            if (_listElements.Count < _maxValue)
            {
                return CreateElement(randomEnemy, true);
            }

            if (_breakLimitPool)
            {
                LimitCheck();
                return CreateElement(randomEnemy, true);
            }

            throw new Exception("pool is over");
        }
    }
}
