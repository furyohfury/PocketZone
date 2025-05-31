using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Game
{
	public sealed class Inventory : IInitializable
	{
		public event Action<string, Sprite> OnItemAdded;
		public event Action<string> OnItemRemoved;
		public event Action<string, int> OnItemCountChanged;

		public IReadOnlyDictionary<string, int> InventoryDictionary => _inventory;
		public int Capacity => _capacity;

		private int _capacity;
		private readonly InventoryConfig _config;
		private readonly Dictionary<string, int> _inventory = new();

		public Inventory(InventoryConfig config)
		{
			_config = config;
		}

		public void Initialize()
		{
			_capacity = _config.Capacity;
		}

		public void AddItem(string id, Sprite icon)
		{
			if (_inventory.Keys.Count >= _capacity)
			{
				return;
			}

			if (_inventory.TryAdd(id, 1))
			{
				OnItemAdded?.Invoke(id, icon);
			}
			else
			{
				_inventory[id]++;
				OnItemCountChanged?.Invoke(id, _inventory[id]);
			}
		}

		public void RemoveItem(string id)
		{
			if (_inventory.TryGetValue(id, out var count) == false)
			{
				throw new ArgumentException($"No item {id} in inventory");
			}

			if (count <= 1)
			{
				_inventory.Remove(id);
				OnItemRemoved?.Invoke(id);
				return;
			}

			_inventory[id]--;
			OnItemCountChanged?.Invoke(id, _inventory[id]);
		}
	}
}