using AdventOfCode.Interfaces;

namespace AdventOfCode.Day07
{
    public class Exercise : IExercise<int, long>
    {
        private string[] _input;

        public Exercise()
        {
            _input = System.IO.File.ReadAllLines("Input\\day7.txt");
        }

        public Exercise(string[] input)
        {
            _input = input;
        }

        public int GetFirstAnswer()
        {
            return 0;
        }

        public long GetSecondAnswer()
        {
            return 0;
        }
    }
}
