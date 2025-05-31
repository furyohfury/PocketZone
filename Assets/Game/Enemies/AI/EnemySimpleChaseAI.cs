using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game
{
	public class EnemySimpleChaseAI : MonoBehaviour
	{
		[SerializeField]
		private MoveComponent _moveComponent;
		[SerializeField]
		private float _detectRange;
		[SerializeField] 
		private LayerMask _layerMask;
		private bool _detected;
		[ShowInInspector]
		private GameObject _target;

		private void Update()
		{
			DetectTarget();
		}

		private void DetectTarget()
		{
			if (_detected)
			{
				return;
			}

			var collider = Physics2D.OverlapCircle(transform.position, _detectRange, _layerMask);
			if (collider != null)
			{
				_target = collider.gameObject;
				_detected = true;
			}
		}

		private void FixedUpdate()
		{
			ChaseTarget();
		}

		private void ChaseTarget()
		{
			if (_detected == false)
			{
				return;
			}

			_moveComponent.Move(_target.transform.position - transform.position);
		}

		private void OnDrawGizmos()
		{
			Gizmos.color = Color.yellow;
			Gizmos.DrawWireSphere(transform.position, _detectRange);
		}
	}
}