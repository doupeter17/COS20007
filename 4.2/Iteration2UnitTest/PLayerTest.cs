using Iteration2;
namespace Iteration2UnitTest
{
    public class PLayerTest
    {

        Player player;
        Inventory inventory;
        Item item1, item2;


        [SetUp]
        public void Setup()
        {
            player = new Player( "a handsome guy", "Thanh");
            inventory = new Inventory();
            item1 = new Item(new string[] { "sword" }, "Metal sword", "Really sharp sword and rare");
            item2 = new Item(new string[] { "spear" }, "Metal spear", "Really sharp spear and rare");

            player.Inventory.Put(item1);
            player.Inventory.Put(item2);
        }
        [Test]
        public void TestPlayerID()
        {
            Assert.AreEqual(player.AreYou("me"), true);
            Assert.AreEqual(player.AreYou("inventory"), true);
        }
        [Test]
        public void TestPlayerLocateItem()
        {
            Assert.AreEqual(player.Locate("sword"), item1);
            Assert.AreEqual(player.Locate("spear"), item2);
            Assert.AreEqual(player.Inventory.HasItem("spear"), true);
            Assert.AreEqual(player.Inventory.HasItem("sword"), true);
        }
        [Test]
        public void TestPlayerLocateSelf()
        {
            Assert.AreEqual(player.Locate("me"), player);
            Assert.AreEqual(player.Locate("inventory"), player);
        }
        [Test]
        public void TestPlayerLocateNothing()
        {
            Assert.AreEqual(player.Locate("anything"), null);
        }
        [Test]
        public void TestDesc()
        {
            Assert.AreEqual(player.FullDescription, "You are Thanh a handsome guy.\nYou are carrying\na Metal sword (sword)\na Metal spear (spear)\n");
        }
    }
}