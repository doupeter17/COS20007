using Iteration2;
namespace Iteration2UnitTest
{
    public class TestItem
    {

        Item items;

        [SetUp]
        public void Setup()
        {
            items = new( new string[]{ "shovel"}, "This might be good","a shovel"  );
        }

        [Test]
        public void TestId()
        {
            Assert.AreEqual(items.AreYou("shovel"), true);
            Assert.AreEqual(items.AreYou("dog"), false);
        }
        public void TestShortDesc()
        {
            Assert.AreEqual(items.ShortDescription, "a shovel (shovel)");
        }
        public void TestLongDesc()
        {
            Assert.AreEqual(items.FullDescription, "This might be good");
        }
    }
}