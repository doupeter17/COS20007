using NUnit.Framework;
using System.Diagnostics.Metrics;
using Clock;
namespace ClockTest
{
    public class Tests
    {
        Clock.Clock _clock;
        [SetUp]
        public void Setup()
        {
            _clock = new Clock.Clock();
        }

        [Test]
        public void TestBegin()
        {
            Assert.AreEqual("00:00:00", _clock.Shows());
        }
        [SetUp]


        [Test]
        public void TestReset()
        {
            for (int i = 0; i < 100000; i++)
            {
                _clock.Ticks();
            }
            _clock.resetTime();
            Assert.AreEqual("00:00:00", _clock.Shows());
        }
        [Test]
        
        public void TestRun()
        {
            _clock.resetTime();
            for (int i = 0; i < 12314; i++)
            {
                _clock.Ticks();
            }
            Assert.AreEqual("03:25:14", _clock.Shows());
        }
        
    }
}