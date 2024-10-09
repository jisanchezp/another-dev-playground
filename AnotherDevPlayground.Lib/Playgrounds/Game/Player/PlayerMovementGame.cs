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
        private string _mapPrint = string.Empty;

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
            PrintMap();
            MovePlayerLeftWithLog();
            PrintMap();
            MovePlayerLeftWithLog();
            PrintMap();
            MovePlayerRightWithLog();
            PrintMap();
            MovePlayerRightWithLog();
            PrintMap();
            MovePlayerRightWithLog();
            PrintMap();
            MovePlayerLeftWithLog();
            PrintMap();
            MovePlayerLeftWithLog();
            PrintMap();
        }

        private void SetSpawnXPosition()
        {
            var spawnPositionX = Random.Shared.Next(64);
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
            {
                Console.WriteLine($"Player moved {direction} successfully. Current position: {_player.CurrentPosition.X}");
                Console.WriteLine();
            }
        }

        private bool MovePlayerRight()
        {
            bool output = false;
            int playerCurrentPosition = _player.CurrentPosition.X;

            if (playerCurrentPosition < _map.Length - 1)
            {
                _player.MoveRight();
                UpdatePlayerOnMap();
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
                _player.MoveLeft();
                UpdatePlayerOnMap();
                output = true;
            }

            return output;
        }

        private void UpdatePlayerOnMap()
        {
            _map[_player.PreviousPosition.X] = (int)MapObjectEnum.Empty;
            _map[_player.CurrentPosition.X] = (int)MapObjectEnum.Player;
        }

        private void PrintMap() 
        {
            Console.WriteLine(string.Join("", _map));
            Console.WriteLine();
        }


        internal enum MapObjectEnum : int
        {
            Empty = 0,
            Player = 1,
            Enemy = 2,
        }
    }
}
