namespace AdventOfCode.Day09
{
    struct LowPoint
    {
        public int Value;
        public int Index;
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
