namespace AnotherDevPlayground.Models.Models
{
    public class Position
    {
        public DimensionCoordinate X { get; set; } = new();
        public DimensionCoordinate Y { get; set; } = new();
        public DimensionCoordinate Z { get; set; } = new();

        public Position(int x = 0, int y = 0, int z = 0)
        {
            X.Value = x;
            Y.Value = y;
            Z.Value = z;
        }
    }
}