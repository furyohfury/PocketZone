using UnityEngine;

namespace Game
{
	public sealed class ShootComponent : MonoBehaviour
	{
		public AndCondition CanShoot = new();

		[SerializeField]
		private Transform _firePoint;
		[SerializeField]
		private GameObject _projectile;

		public void Shoot()
		{
			if (CanShoot.Invoke() == false)
			{
				return;
			}

			Instantiate(_projectile, _firePoint.position, _firePoint.rotation);
		}
	}
}