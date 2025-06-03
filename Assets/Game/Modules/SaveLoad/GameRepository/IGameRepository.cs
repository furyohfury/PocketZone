namespace SaveLoad
{
	public interface IGameRepository
	{
		void LoadState();

		void SaveState();

		T GetData<T>();

		bool TryGetData<T>(out T value);

		void SetData<T>(T value);
	}
}