using UnityEngine;

namespace Game
{
	public sealed class Player : MonoBehaviour
	{
		[SerializeField]
		private LifeComponent _lifeComponent;
		[SerializeField]
		private MoveComponent _moveComponent;

		private void Awake()
		{
			_moveComponent.CanMove.AddCondition(() => _lifeComponent.Health > 0);
		}
	}
}