using Assets.Scripts.Core.Skills;
using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Assets.Scripts.Pool
{
    [Serializable]
    public class PoolSideBullet
    {
        [SerializeField] private SideBullet _bulletPrefab;
        [SerializeField] private Transform[] _transform;
        [SerializeField] private List<SideBullet> _listElements;
        [SerializeField] private GameObject _poolContainer;
        [SerializeField] private int _minValue;
        [SerializeField] private int _maxValue;
        [SerializeField] private bool _breakLimitPool;

        public SideBullet Bullet => _bulletPrefab;

        public Transform[] Transforms => _transform;

        public int MinValue => _minValue;

        public void LimitCheck()
        {
            if (!_breakLimitPool)
                return;
            else _maxValue = int.MaxValue;
        }

        public void CreatePool()
        {
            _listElements = new List<SideBullet>(_minValue);

            for (int i = 0; i < _minValue; i++)
            {
                CreateElement();
            }
        }

        public SideBullet CreateElement(bool isActive = false)
        {
            var element = Object.Instantiate(_bulletPrefab, _poolContainer.transform);
            element.gameObject.SetActive(isActive);

            _listElements.Add(element);
            return element;
        }

        private bool TryGetElement(out SideBullet poolObject)
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

        public SideBullet GetFreeElement()
        {
            if (TryGetElement(out var elenemt))
            {
                return elenemt;
            }

            if (_listElements.Count < _maxValue)
            {
                return CreateElement(true);
            }

            if (_breakLimitPool)
            {
                LimitCheck();
                return CreateElement(true);
            }

            throw new Exception("pool is over");
        }
    }
}