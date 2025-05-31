using UnityEngine;

namespace Game
{
	public sealed class DropItemsOnDeathComponent : MonoBehaviour
	{
		[SerializeField]
		private GameObject[] _items;
		
		private void OnDestroy()
		{
			if (Application.isPlaying == false)
			{
				return;
			}
			
			for (int i = 0, count = _items.Length; i < count; i++)
			{
				var item = _items[i];
				Instantiate(item, transform.position, Quaternion.identity);
			}
		}
	}
}