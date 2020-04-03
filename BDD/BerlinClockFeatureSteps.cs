using TechTalk.SpecFlow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BerlinClock.Classes;

namespace BerlinClock
{
    [Binding]
    public class TheBerlinClockSteps
    {
        private readonly ITimeConverter berlinClock = new TimeConverter();
        private string theTime;
                
        [When(@"the time is ""(.*)""")]
        public void WhenTheTimeIs(string time)
        {
            theTime = time;
        }
        
        [Then(@"the clock should look like")]
        public void ThenTheClockShouldLookLike(string theExpectedBerlinClockOutput)
        {
            var actualOutput = berlinClock.ConvertTime(theTime);
            Assert.AreEqual(actualOutput, theExpectedBerlinClockOutput);
        }

    }
}
