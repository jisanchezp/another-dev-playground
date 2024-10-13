using AnotherDevPlayground.Lib.Playgrounds.DataTypePlaygrounds;
using AnotherDevPlayground.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
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

        public async void Start()
        {
            SetPlayerSpawnPositionX();
            AddPlayerToMap();
            await ActiveGameLoop();

            Console.WriteLine("You've just hit the wall...");
        }

        private void AddPlayerToMap()
        {
            _map[_player.CurrentPosition.X] = (int)MapObjectEnum.Player;
        }

        private async Task ActiveGameLoop()
        {
            Console.Write("Press A to go left or D to go right: ");
            Console.WriteLine();

            do
            {
                Task loopTask = Task.Run(async () =>
                {
                    ConsoleKey choice = Console.ReadKey().Key;

                    switch (choice)
                    {
                        case ConsoleKey.A:
                            await MovePlayerLeft();
                            PrintMap();
                            break;
                        case ConsoleKey.D:
                            await MovePlayerRight();
                            PrintMap();
                            break;
                    }

                    Thread.Sleep(150);
                    //await Task.Delay(150);
                });

                loopTask.Wait();
            }
            while (HasPlayerCollidedWithWall() == false);
        }

        private bool HasPlayerCollidedWithWall()
        {
            var playerCollidedLeftWall = _player.CurrentPosition.X == _leftWallIndex;
            var playerCollidedRightWall = _player.CurrentPosition.X == _rightWallIndex;

            return playerCollidedLeftWall || playerCollidedRightWall;
        }

        private void SetPlayerSpawnPositionX()
        {
            var spawnPositionX = Random.Shared.Next(minValue: _leftWallIndex+1, maxValue: _rightWallIndex-1);
            _player.SetPositionX(spawnPositionX);
        }

        private async Task MovePlayerLeftWithLog()
        {
            var direction = "left";
            var hasPlayerMoved = await MovePlayerLeft();
            LogPlayerMovement(hasPlayerMoved, direction);
        }

        private async Task MovePlayerRightWithLog()
        {
            var direction = "right";
            var hasPlayerMoved = await MovePlayerRight();
            LogPlayerMovement(hasPlayerMoved, direction);
        }

        private void LogPlayerMovement(bool hasPlayerMoved, string direction)
        {
            if (hasPlayerMoved)
            {
                Console.WriteLine($"Player moved {direction} successfully. Current position: {_player.CurrentPosition.X}");
                Console.WriteLine();
            }
        }

        private async Task<bool> MovePlayerRight()
        {
            bool output = false;
            int playerCurrentPosition = _player.CurrentPosition.X;

            if (playerCurrentPosition < _map.Length - 1)
            {
                await _player.MoveRight();
                UpdatePlayerOnMap();
                output = true;
            }

            return output;
        }

        private async Task<bool> MovePlayerLeft()
        {
            bool output = false;
            int playerCurrentPosition = _player.CurrentPosition.X;

            if (playerCurrentPosition > 0)
            {                
                await _player.MoveLeft();
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
            Console.Clear();            
            Console.WriteLine(string.Join("", _map));
        }

        internal enum MapObjectEnum : int
        {
            Empty = 0,
            Player = 1,
            Enemy = 2,
        }
    }
}
