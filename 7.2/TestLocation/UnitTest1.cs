using SwinAdventure;
namespace TestLocation
{
    public class Tests
    {
        LookCommand command;
        Player player1;
        Item gem, sword;
        Location valhalla;
        [SetUp]
        
        public void Setup()
        {
            sword = new Item(new string[] { "sword" }, "Sword", "Very sharp hehe");
            gem = new Item(new string[] { "gem" }, "Gem", "Valuable Item");
            valhalla = new Location(new string[] {"valhalla"}, "Valhalla", "Sanctuary of Viking warriors");
            player1 = new Player("A handsome guy", "Thanh");
            player1.Location = valhalla;

            valhalla.Inventory.Put(sword);
            player1.Inventory.Put(gem);

        }

        [Test]
        public void TestLocationLocateSelf()
        {
            Assert.AreEqual(valhalla, valhalla.Locate("valhalla"));
            
        }
        [Test]
        public void TestLocationLocateItem()
        {
            Assert.AreEqual(valhalla, valhalla.Locate("valhalla"));
        }
        [Test]
        public void TestPLayerLocateItem()
        {
            // Sword is in Valhalla(Location) and not in Player's Inventory, so test it!
            Assert.AreEqual(sword, player1.Locate("Sword"));
        }
    }
}