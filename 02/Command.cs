using System;

namespace _02
{
    class Command
    {
        public int Units;
        public string Direction;

        public int AbsoluteUnits
        {
            get
            {
                if (Direction == "down")
                    return Units;

                if (Direction == "up")
                    return Units * -1;

                return 0;
            }
        }


        public Command(string input)
        {
            var arguments = input.Split(" ");
            Direction = arguments[0];
            Units = Convert.ToInt32(arguments[1]);
        }
    }
}
