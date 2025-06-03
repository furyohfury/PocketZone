using UnityEngine;

namespace Game
{
    public class EnemyService
    {
        public Transform Container;

        public GameObject[] GetEnemies()
        {
            return GameObject.FindGameObjectsWithTag(Tags.Enemy);
        }
    }    
}