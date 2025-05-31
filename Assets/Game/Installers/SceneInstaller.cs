using UnityEngine;
using Zenject;

namespace Game
{
	public class SceneInstaller : MonoInstaller
	{
		[SerializeField]
		private GameObject _player;
		[SerializeField] 
		private InventoryConfig _inventoryConfig;
		[SerializeField] 
		private ItemView _itemViewPrefab;

		public override void InstallBindings()
		{
			Container.Bind<InputControls>()
			         .AsSingle();

			Container.BindInterfacesAndSelfTo<PlayerInputReader>()
			         .AsSingle();

			Container.BindInterfacesAndSelfTo<PlayerController>()
			         .AsSingle()
			         .WithArguments(_player);

			Container.Bind<InventoryConfig>()
			         .FromInstance(_inventoryConfig)
			         .AsSingle();

			Container.BindInterfacesAndSelfTo<Inventory>()
			         .AsSingle();

			Container.BindInterfacesAndSelfTo<PlayerPickController>()
			         .AsSingle()
			         .WithArguments(_player);

			Container.Bind<InventoryView>()
			         .FromComponentInHierarchy()
			         .AsSingle();

			Container.Bind<ItemView>()
			         .FromInstance(_itemViewPrefab)
			         .AsSingle();

			Container.BindInterfacesAndSelfTo<ItemViewFactory>()
			         .AsSingle();

			Container.BindInterfacesAndSelfTo<InventoryPresenter>()
			         .AsSingle();
		}
	}
}