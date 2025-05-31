using UnityEngine;
using UnityEngine.UI;

namespace Game
{
	public sealed class Healthbar : MonoBehaviour
	{
		[SerializeField]
		private Image _bar;

		public void SetBar(float ratio)
		{
			_bar.fillAmount = Mathf.Clamp01(ratio);
		}
	}
}