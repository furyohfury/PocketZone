using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game
{
	[CreateAssetMenu(fileName = "EnemiesPrefabs", menuName = "Create config/EnemiesPrefabs")]
	public class EnemiesPrefabs : SerializedScriptableObject
	{
		public Dictionary<string, GameObject> Prefabs;
	}
}