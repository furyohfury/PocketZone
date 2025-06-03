using Zenject;

namespace SaveLoad
{
	public interface ISaveLoader
	{
		void LoadGame(IGameRepository repository, DiContainer container);

		void SaveGame(IGameRepository repository, DiContainer container);
	}
}