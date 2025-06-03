using UnityEngine;

namespace Game
{
    public class PlayerService
    {
        public Player Player => _player;

        private Player _player;

        public PlayerService(Player player)
        {
            _player = player;
        }
    }
}