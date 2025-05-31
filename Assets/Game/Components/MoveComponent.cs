using UnityEngine;

namespace Game
{
	public class MoveComponent : MonoBehaviour
	{
		public AndCondition CanMove = new(); 
			
		[SerializeField]
		private float _speed;
		[SerializeField]
		private Rigidbody2D _rigidbody2D;

		public void Move(Vector2 direction)
		{
			if (CanMove.Invoke() == false)
			{
				return;
			}
			
			_rigidbody2D.MovePosition(_rigidbody2D.position + direction.normalized * _speed * Time.deltaTime);
		}
	}
}