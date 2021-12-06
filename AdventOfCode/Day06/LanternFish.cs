using System;

namespace AdventOfCode.Day06
{
    class LanternFish
    {
        public event EventHandler BabyBorn;

        private int _timer;

        public LanternFish()
        {
            _timer = 8;
        }

        public LanternFish(int timer)
        {
            _timer = timer;
        }

        internal void PassDay()
        {
            if (_timer == 0)
            {
                _timer = 6;
                OnBabyBorn(null);
            }
            else
            {
                _timer--;
            }
        }

        protected virtual void OnBabyBorn(EventArgs e)
        {
            EventHandler handler = BabyBorn;
            handler?.Invoke(this, e);
        }

        public override string ToString()
        {
            return _timer.ToString();
        }
    }
}
