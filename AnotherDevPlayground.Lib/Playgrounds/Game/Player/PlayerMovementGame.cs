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
            _player.Position.X = Random.Shared.Next(100);
            _map[_player.Position.X] = (int)MapObjectEnum.Player;
            MoveLeftWithLog();
            MoveLeftWithLog();
            MoveLeftWithLog();
            MoveRightWithLog();
            MoveRightWithLog();
            MoveRightWithLog();
            MoveLeftWithLog();
            MoveLeftWithLog();
        }


        private void MoveLeftWithLog()
        {
            var hasPlayerMoved = MoveLeft();
            LogPlayerMovement(hasPlayerMoved, "left");
        }

        private void MoveRightWithLog()
        {
            var hasPlayerMoved = MoveRight();
            LogPlayerMovement(hasPlayerMoved, "right");
        }

        private void LogPlayerMovement(bool hasPlayerMoved, string direction)
        {
            if (hasPlayerMoved)
                Console.WriteLine($"Player moved {direction} successfully. Current position: {_player.Position.X}");
        }

        private bool MoveRight()
        {
            bool output = false;

            if (_player.Position.X < _map.Length - 1)
            {
                _map[_player.Position.X] = (int)MapObjectEnum.Empty;
                _player.Position.X += 1;
                _map[_player.Position.X] = (int)MapObjectEnum.Player;
                output = true;
            }

            return output;
        }

        private bool MoveLeft()
        {
            bool output = false;

            if (_player.Position.X > 0)
            {
                _map[_player.Position.X] = (int)MapObjectEnum.Empty;
                _player.Position.X -= 1;
                _map[_player.Position.X] = (int)MapObjectEnum.Player;
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
