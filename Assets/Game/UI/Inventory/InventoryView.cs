using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game
{
	public class InventoryView : MonoBehaviour
	{
		public event Action<string> OnClickedItem;
		private readonly Dictionary<string, ItemView> _items = new();

		public void AddItem(string id, ItemView itemView)
		{
			_items.Add(id, itemView);
			itemView.OnClickedItem += OnClickedItemView;
			itemView.transform.SetParent(gameObject.transform);
		}

		private void OnClickedItemView(ItemView obj)
		{
			var id = _items.FirstOrDefault(pair => pair.Value == obj).Key;
			OnClickedItem?.Invoke(id);
		}

		public void ChangeItemCount(string id, string count)
		{
			var itemView = _items[id];
			itemView.SetCount(count);
		}

		public void RemoveItem(string id)
		{
			var itemView = _items[id];
			_items.Remove(id);
			itemView.OnClickedItem -= OnClickedItemView;
			Destroy(itemView.gameObject);
		}
	}
}