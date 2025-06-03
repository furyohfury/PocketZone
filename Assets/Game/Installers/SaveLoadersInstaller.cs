using UnityEngine;
using Zenject;

namespace Game
{
	public sealed class SaveLoadersInstaller : MonoInstaller
	{
		[SerializeField] 
		private EnemiesPrefabs _enemiesPrefabs;

		public override void InstallBindings()
		{
			Container.BindInterfacesAndSelfTo<PlayerSaveLoader>()
			         .AsSingle();
			
			Container.BindInterfacesAndSelfTo<EnemiesSaveLoader>()
			         .AsSingle()
			         .WithArguments(_enemiesPrefabs.Prefabs);
		}
	}
}