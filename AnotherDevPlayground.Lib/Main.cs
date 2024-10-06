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
        }
    }
}
