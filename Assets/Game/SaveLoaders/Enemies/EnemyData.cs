using UnityEngine;

namespace Game
{
	public struct EnemyData
	{
		public int InstanceId;
		public string Id;
		public Vector3 Position;
		public int Health;

		public EnemyData(int instanceId, string id, Vector3 position, int health)
		{
			InstanceId = instanceId;
			Id = id;
			Position = position;
			Health = health;
		}
	}
}