namespace AnotherDevPlayground.Models.Models
{
    public class DimensionCoordinate : IDimensionCoordinate
    {

        private const int DEFAULT_DIMENSION_STEP = 1;
        private int _currentValue;
        private int _previousValue;
        private readonly int _step;

        public string Name { get; set; } = string.Empty;

        public int Value
        {
            get { return Value; }
            set
            {
                _previousValue = _currentValue;
                _currentValue = value;
            }
        }

        public DimensionCoordinate(int step = DEFAULT_DIMENSION_STEP)
        {
            _step = step;
        }

        public int PreviousValue { get {  return _previousValue; } }

        public void Decrease()
        {
            Value -= _step;
        }

        public void Increase()
        {
            Value += _step;
        }
    }
}