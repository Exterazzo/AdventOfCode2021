using System.Diagnostics;

namespace AdventOfCode.Day09
{
    [DebuggerDisplay("X = {X}, Y = {Y}, Value = {Value}")]
    struct LowPoint
    {
        public int Value;
        public int X;
        public int Y;
        public int? Previous;
        public int? Next;

        public bool IsLowerHorizontally
        {
            get
            {
                if (Previous.HasValue && Next.HasValue && Value < Previous.Value && Value < Next.Value)
                    return true;

                if (!Previous.HasValue && Next.HasValue && Value < Next.Value)
                    return true;

                if (!Next.HasValue && Previous.HasValue && Value < Previous.Value)
                    return true;

                return false;
            }
        }
    }
}
