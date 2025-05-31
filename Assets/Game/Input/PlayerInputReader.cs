using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Game
{
	public sealed class PlayerInputReader : 
		IInitializable, 
		InputControls.IPlayerActions,
		IDisposable
	{
		public Vector2 MoveDirection => _moveDirection;
		public event Action OnShootEvent; 

		private Vector2 _moveDirection;
		private readonly InputControls _inputControls;

		public PlayerInputReader(InputControls inputControls)
		{
			_inputControls = inputControls;
		}

		public void Initialize()
		{
			_inputControls.Player.SetCallbacks(this);
			_inputControls.Player.Enable();
		}

		public void OnMovement(InputAction.CallbackContext context)
		{
			_moveDirection = context.ReadValue<Vector2>();
		}

		public void OnShoot(InputAction.CallbackContext context)
		{
			OnShootEvent?.Invoke();
		}

		public void Dispose()
		{
			_inputControls.Player.Disable();
		}
	}
}