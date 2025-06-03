namespace Game
{
    public class PlayerSaveLoader : SaveLoader<PlayerData, PlayerService>
    {
        public override void SetupData(PlayerService service, PlayerData data)
        {
            var player = service.Player;
            player.GetComponentInChildren<LifeComponent>().Health = data.Health;
            player.transform.position = data.Position;
        }

		protected override PlayerData ConvertToData(PlayerService service)
        {
            var player = service.Player;

            return new PlayerData()
            {
                Health = player.GetComponentInChildren<LifeComponent>().Health;
                Position = player.transform.position;
            }
        }
    }
}