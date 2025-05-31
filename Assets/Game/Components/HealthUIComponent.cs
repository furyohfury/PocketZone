using System;
using UnityEngine;

namespace Game
{
	public class HealthUIComponent : MonoBehaviour
	{
		[SerializeField]
		private Healthbar _healthbar;
		[SerializeField]
		private LifeComponent _lifeComponent;

		private void Start()
		{
			_lifeComponent.OnHealthChanged += OnHealthChanged;
		}

		private void OnHealthChanged(int health)
		{
			var ratio = (float) health / _lifeComponent.MaxHealth;
			_healthbar.SetBar(ratio);
		}
	}
}