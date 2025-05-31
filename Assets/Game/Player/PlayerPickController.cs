using System;
using UnityEngine;
using Zenject;

namespace Game
{
	public sealed class PlayerPickController : IInitializable, IDisposable
	{
		private readonly PickerComponent _pickerComponent;
		private readonly Inventory _inventory;

		public PlayerPickController(GameObject player, Inventory inventory)
		{
			_pickerComponent = player.GetComponentInChildren<PickerComponent>();
			_inventory = inventory;
		}


		public void Initialize()
		{
			_pickerComponent.OnPicked += OnPicked;
		}

		private void OnPicked(PickableComponent obj)
		{
			var objID = obj.ID;
			var objIcon = obj.Icon;
			_inventory.AddItem(objID, objIcon);
		}

		public void Dispose()
		{
			_pickerComponent.OnPicked -= OnPicked;
		}
	}
}