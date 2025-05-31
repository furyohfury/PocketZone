using UnityEngine;

namespace Game
{
	public sealed class ItemViewFactory
	{
		private ItemView _prefab;

		public ItemViewFactory(ItemView prefab)
		{
			_prefab = prefab;
		}

		public ItemView Create()
		{
			var view = Object.Instantiate(_prefab);
			return view;
		}
	}
}