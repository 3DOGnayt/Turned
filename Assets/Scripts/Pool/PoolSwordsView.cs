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

        private void Awake()
        {
            poolBullet.CreatePool();
            poolSideBullet.CreatePool();
            poolBulletEx.CreatePool();
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))                
                FireSword();
            if (Input.GetMouseButtonDown(1))
                BigSword();
            if (Input.GetKeyDown(KeyCode.E))
                ExSword();
        }

        private void FireSword()
        {
            foreach (var position in poolBullet.Transforms)
            {
                poolBullet.GetFreeElement().SmallBullet(position);
            }            
        }

        private void BigSword()
        {
            foreach (var position in poolSideBullet.Transforms)
            {
                poolSideBullet.GetFreeElement().BigBullet(position);
            }            
        }

        private void ExSword()
        {
            foreach (var position in poolBulletEx.Transforms)
            {
                poolBulletEx.GetFreeElement().ExBullet(position);
            }            
        }
    }
}
