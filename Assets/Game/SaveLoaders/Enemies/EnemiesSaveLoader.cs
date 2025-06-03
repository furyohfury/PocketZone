using System.Collections.Generic;
using System.Linq;
using SaveLoad;
using UnityEngine;

namespace Game
{
    public class EnemiesSaveLoader : SaveLoader<EnemyData[], EnemyService>
    {
        private readonly Dictionary<string, GameObject> _prefabs;

		public EnemiesSaveLoader(Dictionary<string, GameObject> prefabs)
		{
			_prefabs = prefabs;
		}

		protected override EnemyData[] ConvertToData(EnemyService service)
		{
			var enemies = service.GetEnemies();
			var saveData = new EnemyData[enemies.Length];
			for(int i = 0; i < enemies.Length; i++)
			{
                var enemy = enemies[i];
				Transform enemyTransform = enemy.transform;
				string enemyId = enemy.GetComponentInChildren<IdComponent>().Id;
				var instanceId = enemy.GetInstanceID();
				var enemyHealth = enemy.GetComponentInChildren<LifeComponent>().Health;

				var enemyData = new EnemyData(
					instanceId,
					enemyId,
					enemyTransform.position,
					enemyHealth);

				saveData[i] = enemyData;
			}

			return saveData;
		}

		protected override void SetupData(EnemyService service, EnemyData[] data)
		{
			var sceneEnemies = service.GetEnemies();
			if (sceneEnemies == null)
			{
				return;
			}

			IEnumerable<EnemyData> enemyDatas = data.ToList();

			foreach (var sceneEnemy in sceneEnemies)
			{
				if (enemyDatas.Any(enemyData => enemyData.InstanceId == sceneEnemy.GetInstanceID()) == false)
				{
					Object.Destroy(sceneEnemy);
				}
			}

			foreach (var enemyData in enemyDatas)
			{
				var sceneEnemy = sceneEnemies.SingleOrDefault(sceneEnemy => sceneEnemy.GetInstanceID() == enemyData.InstanceId);
				if (sceneEnemy != default)
				{
					SetupExistingEnemy(sceneEnemy, enemyData);
				}
				else
				{
					CreateNewEnemy(enemyData, service.Container);
				}
			}
		}

		private static void SetupExistingEnemy(GameObject sceneEnemy, EnemyData enemyData)
		{
			var enemyTransform = sceneEnemy.transform;
			enemyTransform.position = enemyData.Position;
			sceneEnemy.GetComponentInChildren<LifeComponent>().Health = enemyData.Health;
		}

		private void CreateNewEnemy(EnemyData enemyData, Transform container)
		{
			var id = enemyData.Id;
			var prefab = _prefabs[id];
			var pos = enemyData.Position;
			var newEnemy = GameObject.Instantiate(prefab, container);
			newEnemy.transform.position = pos;
			newEnemy.GetComponentInChildren<LifeComponent>().Health = enemyData.Health;
		}
    }
}