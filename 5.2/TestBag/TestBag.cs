using SwinAdventure;
namespace TestBag
{
    public class Tests
    {
        Bag bag, bag2;
        Item item1, item2, item3;
        [SetUp]
        public void Setup()
        {
            bag = new Bag(new string[] { "bag" }, "Old Bag", "This bag is from an homeless man");
            bag2 = new Bag(new string[] { "bag2" }, "Friend's Bag", "This bag is from your teammate");
            item1 = new Item(new string[] { "sword" }, "Gold Sword", "This sword has been sold from a merchant");
            item2 = new Item(new string[] { "coin" }, "Gold Coin", "You can buy many things with this item");
            item3 = new Item(new string[] { "SilverCoin" }, "Silver Coin", "You can buy many things with this item");
            bag.Inventory.Put(bag2);
            bag.Inventory.Put(item1);
            bag.Inventory.Put(item2);
            bag2.Inventory.Put(item3);
        }

        [Test]
        public void LocateItem()
        {
            Assert.AreEqual(bag.Locate("sword"),item1);
            Assert.AreEqual(bag.Locate("coin"), item2);
        }
        [Test]
        public void LocateSelf()
        {
            Assert.AreEqual(bag.Locate("bag"), bag);
        }
        [Test]
        public void LocateNothing()
        {
            Assert.AreEqual(bag.Locate("random"), null);
        }
        [Test]
        public void FullDesc()
        {
            Assert.AreEqual(bag.FullDescription, "In the Old Bag you can see:\na Friend's Bag (bag2)\na Gold Sword (sword)\na Gold Coin (coin)\n");
        }
        [Test]
        public void BaginBag()
        {
            Assert.AreEqual(bag.Locate("bag2"),bag2);
            Assert.AreEqual(bag.Locate("SilverCoin"), null);
        }
    }
}