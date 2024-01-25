using Assets.Scripts.Skills;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Pool
{
    public class PoolSwordsView : MonoBehaviour
    {
        [SerializeField] private PoolBullet poolBullet;
        [Space(20)]
        [SerializeField] private PoolSideBullet poolSideBullet;
        [Space(20)]
        [SerializeField] private PoolBulletEx poolBulletEx;
        [Space(20)]
        [SerializeField] private SkillTime _skillTime;
        [SerializeField] private List<float> _timeSet;

        public List<float> TimeSet => _timeSet;

        private void Awake()
        {
            poolBullet.CreatePool();
            poolSideBullet.CreatePool();
            poolBulletEx.CreatePool();

            foreach (var item in _skillTime.Time)
            {
                _timeSet.Add(item.Time);
            }
        }

        private void Update()
        {
            var time = _skillTime.Time;

            for (int i = 0; i < _timeSet.Count; i++) TimeChecking(i);

            if (Input.GetMouseButtonDown(0) && time[0].Time == _timeSet[0])    
                FireSword();
            if (Input.GetMouseButtonDown(1) && time[1].Time == _timeSet[1])
                BigSword();
            if (Input.GetKeyDown(KeyCode.E) && time[2].Time == _timeSet[2])
                ExSword();
        }

        public bool SetTime(int skill)
        {
            var time = _skillTime.Time;

            if (time[skill].Time != _timeSet[skill]) return false;
            else return true;
        }

        private void TimeChecking(int skill)
        {
            if (_timeSet[skill] == _skillTime.Time[skill].Time) return;

            _timeSet[skill] -= Time.deltaTime;

            if (_timeSet[skill] <= 0) _timeSet[skill] = _skillTime.Time[skill].Time;
        }

        private void FireSword()
        {
            foreach (var position in poolBullet.Transforms)
            {
                poolBullet.GetFreeElement().SmallBullet(position);
            }

            _timeSet[0] -= 0.1f;
        }

        private void BigSword()
        {
            foreach (var position in poolSideBullet.Transforms)
            {
                poolSideBullet.GetFreeElement().BigBullet(position);
            }

            _timeSet[1] -= 0.1f;
        }

        private void ExSword()
        {
            foreach (var position in poolBulletEx.Transforms)
            {
                poolBulletEx.GetFreeElement().ExBullet(position);
            }

            _timeSet[2] -= 0.1f;
        }
    }
}
