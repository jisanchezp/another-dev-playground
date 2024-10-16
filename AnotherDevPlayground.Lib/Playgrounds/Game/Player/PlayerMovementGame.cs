using AnotherDevPlayground.Lib.Playgrounds.DataTypePlaygrounds;
using AnotherDevPlayground.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
        private readonly object _turnLock = new(); // object used instead System.Threading.Lock in version lower than C# 13

        public PlayerMovementGame(Player player, int mapSize)
        {
            _player = player;
            _map = new int[mapSize];
            _leftWallIndex = 0;
            _rightWallIndex = _map.Length - 1;
        }

        public void Start()
        {
            SetPlayerSpawnPositionX();
            AddPlayerToMap();
            ActiveGameLoop();

            Console.WriteLine("You've just hit the wall...");
        }

        private void AddPlayerToMap()
        {
            _map[_player.CurrentPosition.X.Value] = (int)MapObjectEnum.Player;
        }

        private void ActiveGameLoop()
        {
            Console.Write("Press A to go left or D to go right: ");
            Console.WriteLine();
            var readKey = ConsoleKey.None;
            var auxKey = -1;
            do
            {
                readKey = Console.ReadKey().Key;
                auxKey = (int) readKey;
                DoPlayerMove(auxKey);
            }
            while (HasPlayerCollidedWithWall() == false);
        }

        private bool DoPlayerMove(int directionKey)
        {
            try
            {
                Console.Beep();
                switch (directionKey)
                {
                    case (int) ConsoleKey.A:
                        MovePlayerLeft();
                        PrintMap();
                        break;
                    case (int) ConsoleKey.D:
                        MovePlayerRight();
                        PrintMap();
                        break;
                    default:
                        return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }            
        }

        private bool HasPlayerCollidedWithWall()
        {
            var playerCollidedLeftWall = _player.CurrentPosition.X.Value == _leftWallIndex;
            var playerCollidedRightWall = _player.CurrentPosition.X.Value == _rightWallIndex;

            return playerCollidedLeftWall || playerCollidedRightWall;
        }

        private void SetPlayerSpawnPositionX()
        {
            var spawnPositionX = Random.Shared.Next(minValue: _leftWallIndex+1, maxValue: _rightWallIndex-1);
            var spawnPosition = new Position();
            spawnPosition.X.Value = spawnPositionX;

            _player.SetPosition(spawnPosition);
        }

        private void MovePlayerLeftWithLog()
        {
            var direction = "left";
            var hasPlayerMoved = MovePlayerLeft();
            LogPlayerMovement(hasPlayerMoved, direction);
        }

        private void MovePlayerRightWithLog()
        {
            var direction = "right";
            var hasPlayerMoved = MovePlayerRight();
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

        private bool MovePlayerRight()
        {
            bool output = false;
            int playerCurrentPosition = _player.CurrentPosition.X.Value;

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
            int playerCurrentPosition = _player.CurrentPosition.X.Value;

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
            _map[_player.CurrentPosition.X.PreviousValue] = (int)MapObjectEnum.Empty;
            _map[_player.CurrentPosition.X.Value] = (int)MapObjectEnum.Player;
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
