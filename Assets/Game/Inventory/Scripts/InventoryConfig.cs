using UnityEngine;

namespace Game
{
	[CreateAssetMenu(fileName = "InventoryConfig", menuName = "Create config/InventoryConfig")]
	public sealed class InventoryConfig : ScriptableObject
	{
		public int Capacity;
	}
}