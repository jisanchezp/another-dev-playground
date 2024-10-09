using AnotherDevPlayground.Lib.Playgrounds.DataTypePlaygrounds;
using AnotherDevPlayground.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace AnotherDevPlayground.Lib
{
    public static class PlaygroundProgram
    {
        public static async Task Start()
        {
            Console.WriteLine("***Loading system ***");
            Console.WriteLine("System Status: Booting");
            await Task.Delay(1500);
            Console.WriteLine("System Status: Online");
            Console.WriteLine();

            Player player = new Player()
            {
                Name = "Playerito"
            };

            int[] map = new int[64];
            player.Position.X = Random.Shared.Next(100);
            map[player.Position.X] = (int) MapObjectEnum.Player;
            
            MoveLeft(map, player);
            ArrayPlayground.PassSingleDimensionalArraysAsArguments();

            ArrayPlayground.ArrayInAllDimensions();
        }

        private static bool MoveLeft(int[] map, Player player)
        {
            bool output = false;

            if (player.Position.X > 0)
            {
                map[player.Position.X] = (int)MapObjectEnum.Empty;
                player.Position.X -= 1;
                map[player.Position.X] = (int)MapObjectEnum.Player;
                output = true;
            }

            return output;
        }
    }

    internal enum MapObjectEnum : int
    {
        Empty = 0,
        Player = 1,
        Enemy = 2,
    }
}
