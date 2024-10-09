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
        private Dictionary<string, string> controlDictionary = new Dictionary<string, string>();
        private readonly int _leftWallIndex;
        private readonly int  _rightWallIndex;

        public PlayerMovementGame(Player player, int mapSize)
        {
            _player = player;
            _map = new int[mapSize];
            _leftWallIndex = 0;
            _rightWallIndex = _map.Length - 1;
    }
        public void Start()
        {
            SetSpawnXPosition();
            _map[_player.CurrentPosition.X] = (int)MapObjectEnum.Player;

            ActiveGameLoop();

            Console.WriteLine("You've just hit the wall...");
        }

        private void ActiveGameLoop()
        {
            do
            {
                Console.Write("Enter A to go left or D to go right: ");
                string? directionInput = Console.ReadLine();

                if (directionInput != null)
                {
                    switch (directionInput.ToUpper())
                    {
                        case "A":
                            MovePlayerLeftWithLog();
                            PrintMap();
                            break;
                        case "D":
                            MovePlayerRightWithLog();
                            PrintMap();
                            break;
                    }
                }

            }
            while (HasPlayerCollidedWithWall() == false);
        }

        private bool HasPlayerCollidedWithWall()
        {
            var playerCollidedLeftWall = _player.CurrentPosition.X == _leftWallIndex;
            var playerCollidedRightWall = _player.CurrentPosition.X == _rightWallIndex;

            return playerCollidedLeftWall || playerCollidedRightWall;
        }

        private void SetSpawnXPosition()
        {
            var spawnPositionX = Random.Shared.Next(minValue: _leftWallIndex+1, maxValue: _rightWallIndex-1);
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
