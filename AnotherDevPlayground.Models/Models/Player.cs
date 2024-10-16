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
        public Position CurrentPosition { get; private set; } = new Position();


        public void MoveLeft()
        {
            CurrentPosition.X.Decrease();
        }

        public void MoveRight()
        {
            CurrentPosition.X.Increase();
        }

        public void SetPosition(Position position)
        {
            CurrentPosition = position;
        }
    }
}
