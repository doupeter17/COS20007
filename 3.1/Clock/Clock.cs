using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clock
{
    public class Clock
    {
        private Counter counter1;
        private int _hour;
        private int _minute;
        private int _second;
        public Clock()
        {
            counter1 = new Counter("counter1");
        }
        public void Ticks()
        {
            counter1.Increment();
        }
        public void resetTime()
        {
            counter1.Reset();
        }
        public string Shows()
        {
            _hour = (counter1.Ticks() / 3600) % 24;
            _minute = (counter1.Ticks() % 3600) / 60;
            _second = (counter1.Ticks() % 3600) % 60;
            return $"{_hour:D2}:{_minute:D2}:{_second:D2}";
        }
    }
}
