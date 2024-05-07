using Iteration2;
namespace Iteration2UnitTest
{
    [TestFixture]
    public class TestInventory
    {
        
        Inventory inventory = new Inventory();
        Item item1, item2;
        [OneTimeSetUp]
        public void Setup()
        {
            item1 = new(new string[] { "bag" }, "Leather Bag", "A wonderful bag");
            inventory.Put(item1);
            item2 = new(new string[] { "pickage" }, "Bronze Pickage", "A wonderful pickage");
            inventory.Put(item2);

        }

        [Test]
        public void TestFind()
        {
            Assert.AreEqual(inventory.HasItem("bag"), true);
        }
        [Test]
        public void TestNoFind()
        {
            Assert.AreEqual(inventory.HasItem("shovel"), false);
        }
        [Test]
        public void TestFetch()
        {
            Assert.That(item2.Equals(inventory.Fetch("pickage")));
        }
        [Test]
        public void TestTake()
        {
            inventory.Take("bag");
            Assert.AreEqual(inventory.HasItem("bag"), false);
        }
        [Test]
        public void TestList()
        {
            
            Assert.AreEqual(inventory.itemList, "a Leather Bag (bag)\na Bronze Pickage (pickage)\n" );
        }
    }
}