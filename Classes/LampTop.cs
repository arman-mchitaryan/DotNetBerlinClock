namespace BerlinClock.Classes
{
    public class LampTop
    {
        private readonly int seconds;

        public LampTop(int seconds)
        {
            this.seconds = seconds;
        }

        public char ReadTime(int seconds) => IsEven(seconds) ? (char)LampState.Yellow : (char)LampState.Off;

        public override string ToString() => ReadTime(seconds).ToString();

        private static bool IsEven(int number) => number % 2 == 0;
    }
}
