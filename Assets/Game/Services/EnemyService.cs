using UnityEngine;

namespace Game
{
    public class EnemyService
    {
        public Transform Container => _container;
        private readonly Transform _container;

        public EnemyService(Transform container)
        {
            _container = container;
        }

        public GameObject[] GetEnemies()
        {
            return GameObject.FindGameObjectsWithTag(Tags.Enemy.ToString());
        }
    }    
}