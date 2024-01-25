using UnityEngine;

namespace Assets.Scripts.Skills
{
    [CreateAssetMenu(fileName = "TimeCousts", menuName = "Settings/TimeCoust")]
    public class SkillTime : ScriptableObject
    {
        [SerializeField] private TimeSkillsSettings[] _time;

        public TimeSkillsSettings[] Time => _time;
    }
}