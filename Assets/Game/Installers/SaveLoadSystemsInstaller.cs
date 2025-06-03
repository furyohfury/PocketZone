using SaveLoad;
using UnityEngine;
using Zenject;

namespace Game
{
	public class SaveLoadSystemsInstaller : MonoInstaller
	{
		[SerializeField] 
		private SaveLoadManager _saveLoadManager;

		public override void InstallBindings()
		{
			Container.Bind<IGameRepository>()
			         .To<GameRepository>()
			         .AsSingle();

			Container.Bind<SaveLoadManager>()
			         .FromInstance(_saveLoadManager)
			         .AsSingle();
		}
	}
}