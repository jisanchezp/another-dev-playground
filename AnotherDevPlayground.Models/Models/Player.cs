using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnotherDevPlayground.Models.Models
{
    public class Player : MovementCoordX
    {
        public int Id { get; set; }
        public string  Name { get; set; } = string.Empty;
        public Position PreviousPosition { get; private set; } = new Position();
        public Position CurrentPosition { get; private set; } = new Position();


        public void MoveLeft()
        {
            PreviousPosition.X = CurrentPosition.X;
            CurrentPosition.X -= 1;
        }

        public void MoveRight()
        {
            PreviousPosition.X = CurrentPosition.X;
            CurrentPosition.X += 1;
        }

        public void SetPositionX(int spawnPositionX)
        {
            CurrentPosition.X = spawnPositionX;
        }
    }
}
