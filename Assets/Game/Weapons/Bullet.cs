using UnityEngine;

namespace Game
{
	public class Bullet : MonoBehaviour
	{
		[SerializeField]
		private MoveComponent _moveComponent;
		[SerializeField]
		private int _damage;

		private void FixedUpdate()
		{
			_moveComponent.Move(transform.right);
		}

		private void OnTriggerEnter2D(Collider2D other)
		{
			if (other.TryGetComponent(out LifeComponent lifeComponent))
			{
				lifeComponent.TakeDamage(_damage);
				Destroy(gameObject);
			}
		}
	}
}