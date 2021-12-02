using System;

namespace _02
{
    class Command
    {
        private int _units;
        public string Direction;

        public bool IsHorizontal => Direction == "forward";

        public int AbsoluteUnits
        {
            get
            {
                if (Direction == "down")
                    return _units;

                if (Direction == "up")
                    return _units * -1;

                return _units;
            }
        }


        public Command(string input)
        {
            var arguments = input.Split(" ");
            Direction = arguments[0];
            _units = Convert.ToInt32(arguments[1]);
        }
    }
}
