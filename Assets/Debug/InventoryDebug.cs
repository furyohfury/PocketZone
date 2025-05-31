using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Game
{
	public sealed class InventoryDebug : MonoBehaviour
	{
		[ShowInInspector]
		public IReadOnlyDictionary<string, int> InventoryDictionary => _inventory.InventoryDictionary;
		
		private Inventory _inventory;

		[Inject]
		private void Construct(Inventory inventory)
		{
			_inventory = inventory;
		}
	}
}