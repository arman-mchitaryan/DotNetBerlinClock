using System.Collections.Generic;

namespace BerlinClock.Classes
{
    public class LampRow
    {
        protected readonly int lampCount;
        protected readonly int timeIntervalCount;
        protected LampState lampState;

        protected List<char> Lamps { get; set; } = new List<char>();

        public LampRow(int lampCount, int timeIntervalCount, LampState lampState)
        {
            this.lampCount = lampCount;
            this.timeIntervalCount = timeIntervalCount;
            this.lampState = lampState;
            ReadTime();
        }

        public void ReadTime()
        {
            for (int i = 0; i < lampCount; i++)
            {
                Lamps.Add(i < timeIntervalCount ? (char)lampState : (char)LampState.Off);
            }
        }

        public override string ToString() => string.Join(string.Empty, Lamps);
    }
}
