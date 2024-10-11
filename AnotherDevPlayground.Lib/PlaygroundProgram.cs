using AnotherDevPlayground.Lib.Playgrounds.DataTypePlaygrounds;
using AnotherDevPlayground.Lib.Playgrounds.Game.PlayerMovementGame;
using AnotherDevPlayground.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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

            int mapSize = 64;
            var playerMovementGame = new PlayerMovementGame(player, mapSize);

            var taskPlayground = new TaskPlayground();
            //taskPlayground.CreateAndRunTasksImplicitly();
            taskPlayground.CreateAndRunTasksExplicitlyLesserControl();

            //playerMovementGame.Start();

            //ArrayPlayground.PassSingleDimensionalArraysAsArguments();
            //ArrayPlayground.ArrayInAllDimensions();
        }
    }
}
