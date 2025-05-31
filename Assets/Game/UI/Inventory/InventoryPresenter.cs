using System;
using UnityEngine;
using Zenject;

namespace Game
{
	public sealed class InventoryPresenter : IInitializable, IDisposable
	{
		private readonly Inventory _inventory;
		private readonly InventoryView _inventoryView;
		private readonly ItemViewFactory _itemViewFactory;

		public InventoryPresenter(Inventory inventory, InventoryView inventoryView, ItemViewFactory itemViewFactory)
		{
			_inventory = inventory;
			_inventoryView = inventoryView;
			_itemViewFactory = itemViewFactory;
		}

		public void Initialize()
		{
			_inventory.OnItemAdded += OnItemAdded;
			_inventory.OnItemCountChanged += OnCountChanged;
			_inventory.OnItemRemoved += OnRemoved;

			_inventoryView.OnClickedItem += OnClickedItem;
		}

		private void OnItemAdded(string id, Sprite icon)
		{
			var view = _itemViewFactory.Create();
			view.SetIcon(icon);
			_inventoryView.AddItem(id, view);
		}

		private void OnCountChanged(string id, int count)
		{
			if (count != 1)
			{
				_inventoryView.ChangeItemCount(id, count.ToString());
			}
			else
			{
				_inventoryView.ChangeItemCount(id, "");
			}
		}

		private void OnRemoved(string id)
		{
			_inventoryView.RemoveItem(id);
		}

		private void OnClickedItem(string id)
		{
			_inventory.RemoveItem(id);
		}

		public void Dispose()
		{
			_inventory.OnItemAdded -= OnItemAdded;
			_inventory.OnItemCountChanged -= OnCountChanged;
			_inventory.OnItemRemoved -= OnRemoved;
			_inventoryView.OnClickedItem -= OnClickedItem;
		}
	}
}