using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnotherDevPlayground.Models.Models
{
    public class Player : IMovementCoordX
    {
        public int Id { get; set; }
        public string  Name { get; set; } = string.Empty;
        public Position PreviousPosition { get; private set; } = new Position();
        public Position CurrentPosition { get; private set; } = new Position();


        public async Task MoveLeft()
        {
            var task = Task.Run(() =>
            {
                PreviousPosition.X = CurrentPosition.X;
                CurrentPosition.X -= 1;
            });

            task.Wait();
        }

        public async Task MoveRight()
        {
            var task = Task.Run(() =>
            {
                PreviousPosition.X = CurrentPosition.X;
                CurrentPosition.X += 1;
            });

            task.Wait();
        }

        public Task SetPositionX(int spawnPositionX)
        {
            CurrentPosition.X = spawnPositionX;

            return Task.CompletedTask;
        }
    }
}
