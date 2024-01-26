using Assets.Scripts.Pool;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private HealthBarFloor _healthBarFloor;
        [Space(20)]
        [SerializeField] private SkillCoust _skillTime;
        [Space(20)]
        [SerializeField] private RestartLevel _restartLevel;
        [SerializeField] private PoolEmenyView _poolEmeny;

        private void Awake()
        {
            Time.timeScale = 1;

            foreach (var item in _restartLevel.Buttons)
            {
                item.onClick.AddListener(_restartLevel.Restart);
            }

            var floor = _healthBarFloor;

            floor.FloorHpPoints.text = floor.Floor.HealthPoint.ToString();
            floor.FloorHpImage.fillAmount = 1;
        }

        private void Update()
        {
            CheckFloorHp();
            CheckSkillIcons();
            CheckEnemyCount();
        }

        private void CheckSkillIcons()
        {
            _skillTime.SetColor();
        }

        private void CheckFloorHp()
        {
            var floor = _healthBarFloor;

            floor.FloorHpPoints.text = floor.Floor.HealthPoint.ToString();
            floor.FloorHpImage.fillAmount = floor.Floor.HealthPoint * 0.1f; // fix / need to find % hp int

            if (floor.Floor.HealthPoint <= 0)
            {
                _restartLevel.Panels[0].SetActive(true);
                Time.timeScale = 0;
            }
        }

        private void CheckEnemyCount()
        {
            if (_poolEmeny.EnemyCount <= 0)
            {
                _restartLevel.Panels[1].SetActive(true);
                Time.timeScale = 0;
            }
        }
    }
}