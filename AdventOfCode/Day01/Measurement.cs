namespace AdventOfCode.Day01
{
    struct Measurement
    {
        int _a;
        int _b;
        int _c;

        public Measurement(int a, int b, int c)
        {
            _a = a;
            _b = b;
            _c = c;
        }

        public int Sum => _a + _b + _c;
    }
}
