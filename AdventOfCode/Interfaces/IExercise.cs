namespace AdventOfCode.Interfaces
{
    public interface IExercise<out T, out S>
    {
        public T GetFirstAnswer();
        public S GetSecondAnswer();
    }
}
