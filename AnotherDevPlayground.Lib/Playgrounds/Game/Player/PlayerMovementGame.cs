using AnotherDevPlayground.Lib.Playgrounds.DataTypePlaygrounds;
using AnotherDevPlayground.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AnotherDevPlayground.Lib.Playgrounds.Game.PlayerMovementGame
{

    internal class PlayerMovementGame
    {
        private int[] _map;
        private Player _player;

        public PlayerMovementGame(Player player, int mapSize)
        {
            _player = player;
            _map = new int[mapSize];
        }
        public void Start()
        {
            SetSpawnXPosition();
            _map[_player.CurrentPosition.X] = (int)MapObjectEnum.Player;
            MovePlayerLeftWithLog();
            MovePlayerLeftWithLog();
            MovePlayerLeftWithLog();
            MovePlayerRightWithLog();
            MovePlayerRightWithLog();
            MovePlayerRightWithLog();
            MovePlayerLeftWithLog();
            MovePlayerLeftWithLog();
        }

        private void SetSpawnXPosition()
        {
            var spawnPositionX = Random.Shared.Next(100);
            _player.SetPositionX(spawnPositionX);
        }

        private void MovePlayerLeftWithLog()
        {
            var hasPlayerMoved = MovePlayerLeft();
            LogPlayerMovement(hasPlayerMoved, "left");
        }

        private void MovePlayerRightWithLog()
        {
            var hasPlayerMoved = MovePlayerRight();
            LogPlayerMovement(hasPlayerMoved, "right");
        }

        private void LogPlayerMovement(bool hasPlayerMoved, string direction)
        {
            if (hasPlayerMoved)
                Console.WriteLine($"Player moved {direction} successfully. Current position: {_player.CurrentPosition.X}");
        }

        private bool MovePlayerRight()
        {
            bool output = false;
            int playerCurrentPosition = _player.CurrentPosition.X;

            if (playerCurrentPosition < _map.Length - 1)
            {
                _map[playerCurrentPosition] = (int)MapObjectEnum.Empty;
                _player.MoveRight();
                _map[playerCurrentPosition] = (int)MapObjectEnum.Player;
                output = true;
            }

            return output;
        }

        private bool MovePlayerLeft()
        {
            bool output = false;
            int playerCurrentPosition = _player.CurrentPosition.X;

            if (playerCurrentPosition > 0)
            {
                _map[playerCurrentPosition] = (int)MapObjectEnum.Empty;
                _player.MoveLeft();
                _map[playerCurrentPosition] = (int)MapObjectEnum.Player;
                output = true;
            }

            return output;
        }


        internal enum MapObjectEnum : int
        {
            Empty = 0,
            Player = 1,
            Enemy = 2,
        }
    }
}
