using System;
using UnityEngine;

namespace Game
{
	[RequireComponent(typeof(Collider2D))]
	public sealed class PickerComponent : MonoBehaviour
	{
		public event Action<PickableComponent> OnPicked;

		private void OnTriggerEnter2D(Collider2D other)
		{
			if (other.TryGetComponent(out PickableComponent pickableComponent) == false)
			{
				return;
			}

			OnPicked?.Invoke(pickableComponent);
			Destroy(pickableComponent.gameObject);
		}
	}
}