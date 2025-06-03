using System;
using SaveLoad;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Game
{
	public class SaveLoadButtons : MonoBehaviour
	{
		[SerializeField]
		private Button _saveButton;
		[SerializeField]
		private Button _loadButton;
		private SaveLoadManager _saveLoadManager;

		[Inject]
		private void Construct(SaveLoadManager saveLoadManager)
		{
			_saveLoadManager = saveLoadManager;
		}

		private void Start()
		{
			_saveButton.onClick.AddListener(OnSave);
			_loadButton.onClick.AddListener(OnLoad);
		}

		private void OnSave()
		{
			_saveLoadManager.Save();
		}

		private void OnLoad()
		{
			_saveLoadManager.Load();
		}

		private void OnDestroy()
		{
			_saveButton.onClick.RemoveListener(OnSave);
			_loadButton.onClick.RemoveListener(OnLoad);
		}
	}
}