using System;
using System.Text;

namespace BerlinClock.Classes
{
    public class TimeConverter : ITimeConverter
    {
        private int Hours { get; set; }

        private int Minutes { get; set; }

        private int Seconds { get; set; }

        private LampTop TopLamp { get; set; }

        private LampRow FirstRow { get; set; }

        private LampRow SecondRow { get; set; }

        private QuarterlyLampRow ThirdRow { get; set; }

        private LampRow FourthRow { get; set; }

        public string ConvertTime(string time)
        {
            ValidateTimeInput(time);
            SetInternalTime(time);
            return ReadTime();
        }

        private void ValidateTimeInput(string time)
        {
            if(time == null)
            {
                throw new ArgumentNullException("The string cannot be null.", nameof(time));
            }

            if(time == string.Empty)
            {
                throw new ArgumentException("The string cannot be empty.", nameof(time));
            }

            if(!TimeSpan.TryParse(time, out TimeSpan timeSpan))
            {
                throw new ArgumentException("The string is in a wrong format: expected format is 'hh:mm:ss'", nameof(time));
            }

            // Excluding the special case of specifying midnight as 24:00:00
            if(time != "24:00:00" && timeSpan.Days > 0)
            {
                throw new ArgumentException("The string is in a wrong format: expected format is 'hh:mm:ss'", nameof(time));
            }
        }

        private string ReadTime()
        {
            return new StringBuilder()
                .AppendLine(TopLamp.ToString())
                .AppendLine(FirstRow.ToString())
                .AppendLine(SecondRow.ToString())
                .AppendLine(ThirdRow.ToString())
                .Append(FourthRow.ToString())
                .ToString();
        }

        private void SetInternalTime(string time)
        {
            ParseTimeValue(time);
            SetNativeClock();
        }

        private void ParseTimeValue(string time)
        {
            var timeComponents = time.Split(':');
            Hours = int.Parse(timeComponents[0]);
            Minutes = int.Parse(timeComponents[1]);
            Seconds = int.Parse(timeComponents[2]);
        }

        private void SetNativeClock()
        {
            TopLamp = new LampTop(Seconds);
            FirstRow = new LampRow(4, Hours / 5, LampState.Red);
            SecondRow = new LampRow(4, Hours % 5, LampState.Red);
            ThirdRow = new QuarterlyLampRow(11, Minutes / 5, LampState.Yellow, LampState.Red);
            FourthRow = new LampRow(4, Minutes % 5, LampState.Yellow);
        }

        public override string ToString() => ReadTime();
    }
}
