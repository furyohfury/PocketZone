using UnityEngine;

namespace Game
{
	public sealed class Zombie : MonoBehaviour
	{
		[SerializeField]
		private LifeComponent _lifeComponent;
		[SerializeField]
		private MoveComponent _moveComponent;

		private void Awake()
		{
			_moveComponent.CanMove.AddCondition(() => _lifeComponent.Health > 0);
		}

		private void Update()
		{
			if (_lifeComponent.Health <= 0)
			{
				Destroy(gameObject);
			}
		}
	}
}