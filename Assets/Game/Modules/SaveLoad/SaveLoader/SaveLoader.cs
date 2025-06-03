using UnityEngine;
using Zenject;

namespace SaveLoad
{
	public abstract class SaveLoader<TData, TService> : ISaveLoader where TService : class
	{
		void ISaveLoader.LoadGame(IGameRepository repository, DiContainer container)
		{
			var service = container.TryResolve<TService>();
			if (service == null)
			{
				Debug.LogWarning($"Can't resolve service {typeof(TService).Name}");
				return;
			}

			if (repository.TryGetData(out TData data))
			{
				SetupData(service, data);
			}
			else
			{
				SetupByDefault(service);
			}
		}

		void ISaveLoader.SaveGame(IGameRepository repository, DiContainer container)
		{
			var service = container.Resolve<TService>();
			var data = ConvertToData(service);
			repository.SetData(data);
		}

		protected abstract void SetupData(TService service, TData data);

		protected abstract TData ConvertToData(TService service);

		protected virtual void SetupByDefault(TService service)
		{
			Debug.LogError($"Didn't find data of type {typeof(TData).FullName} to service: {service.GetType().FullName}");
		}
	}
}