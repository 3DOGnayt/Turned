using Assets.Scripts.Pool;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    [Serializable]
    public class SkillCoust
    {
        [SerializeField] private Image[] _skillIcon;
        [SerializeField] private PoolSwordsView _poolSwordsView;

        public void SetColor()
        {
            var time = _poolSwordsView.TimeSet;

            for (int i = 0; i < time.Count; i++)
            {
                if (!_poolSwordsView.SetTime(i))
                {
                    _skillIcon[i].color = Color.Lerp(Color.white, new Color(255, 255, 255, 0), time[i]); // chenges work like 0=> 1; fix
                }
            }
        }
    }
}