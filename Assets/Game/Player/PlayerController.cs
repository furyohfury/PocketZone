using UnityEngine;
using Zenject;

namespace Game
{
	public class PlayerController : IInitializable, IFixedTickable
	{
		private readonly PlayerInputReader _inputReader;
		private readonly MoveComponent _moveComponent;
		private ShootComponent _shootComponent;

		public PlayerController(GameObject player, PlayerInputReader inputReader)
		{
			_inputReader = inputReader;
			_moveComponent = player.GetComponent<MoveComponent>();
			_shootComponent = player.GetComponent<ShootComponent>();
		}

		public void Initialize()
		{
			_inputReader.OnShootEvent += OnShoot;
		}

		public void FixedTick()
		{
			var moveDirection = _inputReader.MoveDirection;
			_moveComponent.Move(new Vector2(moveDirection.x, 0));
		}

		private void OnShoot()
		{
			_shootComponent.Shoot();
		}
	}
}