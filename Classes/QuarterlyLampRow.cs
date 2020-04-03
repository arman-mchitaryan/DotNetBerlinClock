namespace BerlinClock.Classes
{
    public class QuarterlyLampRow : LampRow
    {
        private readonly LampState querterLampState;

        public QuarterlyLampRow(int lampCount, int timeInterval, LampState defaultLampState, LampState quarterLampState)
            : base(lampCount, timeInterval, defaultLampState)
        {
            this.querterLampState = quarterLampState;
            UpdateTime();
        }

        private void UpdateTime()
        {
            // In this row the 3rd, 6th and 9th lamp are red and indicate the first quarter, half and last quarter of an hour.
            // The other lamps remain yellow.
            for (int i = 0; i < Lamps.Count; i++)
            {
                if ((i + 1) % 3 == 0 && Lamps[i] != (char)LampState.Off)
                {
                    Lamps[i] = (char)querterLampState;
                }
            }
        }
    }
}
