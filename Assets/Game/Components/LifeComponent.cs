using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game
{
	public class LifeComponent : MonoBehaviour
	{
		public event Action<int> OnHealthChanged;
		public int Health {get => _currentHealth; set => _currentHealth = value;}
		public int MaxHealth => _maxHealth;

		[SerializeField]
		private int _maxHealth = 5;
		[SerializeField]
		private int _currentHealth = 5;

		[Button]
		public void TakeDamage(int delta)
		{
			_currentHealth = Mathf.Max(0, _currentHealth - delta);
			OnHealthChanged?.Invoke(_currentHealth);
		}
	}
}