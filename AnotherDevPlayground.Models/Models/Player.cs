using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnotherDevPlayground.Models.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string  Name { get; set; } = string.Empty;
        public Position Position { get; set; } = new Position();                
    }
}
