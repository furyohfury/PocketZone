using UnityEngine;

namespace Game
{
	public sealed class PickableComponent : MonoBehaviour
	{
		public Sprite Icon => _icon;
		public string ID => _id;

		[SerializeField]
		private Sprite _icon;
		[SerializeField]
		private string _id;
	}
}