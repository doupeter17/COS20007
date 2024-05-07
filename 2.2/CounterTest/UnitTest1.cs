using Lab31ClockClass;
namespace CounterTest
{
    public class Tests
    {
        Counter _counter;
        [SetUp]
        public void Setup()
        {
            _counter = new Counter();
        }

        [Test]
        public void TestBegin()
        {
            Assert.AreEqual(0, _counter.Ticks());
        }
        [Test]
        public void TestIncrease()
        {
            _counter.Increment();
            Assert.AreEqual(1, _counter.Ticks());
        }
        [Test]
        public void TestReset()
        {
            _counter.Reset();
            Assert.AreEqual(0, _counter.Ticks());
        }
    }
}