using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
	public class ItemView : MonoBehaviour
	{
		public event Action<ItemView> OnClickedItem;

		[SerializeField]
		private Image _image;
		[SerializeField]
		private TMP_Text _count;
		[SerializeField]
		private Button _button;

		private void Awake()
		{
			_button.onClick.AddListener(OnClicked);
		}

		private void OnClicked()
		{
			OnClickedItem?.Invoke(this);
		}

		public void SetIcon(Sprite sprite)
		{
			_image.sprite = sprite;
		}

		public void SetCount(string count)
		{
			_count.text = count;
		}

		private void OnDestroy()
		{
			_button.onClick.RemoveListener(OnClicked);
		}
	}
}