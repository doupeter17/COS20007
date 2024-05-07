using SwinAdventure;
using System.Runtime.InteropServices;
using System.Linq;
namespace TestIteration4
{
    public class Tests
    {
        LookCommand command;
        Player player, playerNothing;
        Item gem, gem2;
        Bag bag1, bagNothing;

        [SetUp]
        public void Setup()
        {
            command = new LookCommand();
            // Assign players
            player = new Player("A handsome guy", "Thanh");
            playerNothing = new Player("This guy don't have anything", "Thien");
            // Define bag and assign it to player
            bagNothing = new Bag(new string[] {"emptybag"}, "Empty Bag", "Just an empty bag");
            bag1 = new Bag(new string[] {"leatherbag"}, "Leather Bag", "This leather bag is historical");

            bag1.Inventory.Put(gem2);
            player.Inventory.Put(bag1);
            // Assign gem to player's inventory
            gem = new Item(new string[] { "gem" }, "Saphire Gem", "A nice gem can be merged into your sword");
            gem2 = new Item(new string[] { "darkgem" }, "Dark Gem", "This gem is cursed");

            player.Inventory.Put(gem);
            playerNothing.Inventory.Put(bagNothing);

        }

        [Test]
        public void TestLookAtMe()
        {
            string commandLine = "look at inventory";
            string[] convertedCommand = commandLine.Trim().Split(' ');
            Assert.AreEqual(command.Excute(player,convertedCommand),player.FullDescription);
        }
        [Test]
        public void TestLookAtGem()
        {
            string commandLine = "look at gem";
            string[] convertedCommand = commandLine.Trim().Split(' ');
            Assert.AreEqual(command.Excute(player, convertedCommand), gem.FullDescription);
        }

        [Test]
        public void TestLookAtUnk()
        {
            string commandLine = "look at gem";
            string[] convertedCommand = commandLine.Trim().Split(' ');
            Assert.AreEqual(command.Excute(playerNothing, convertedCommand),"I can't find the gem");
        }
        [Test]
        public void TestLookAtGemInMe()
        {
            string commandLine = "look at gem in inventory";
            string[] convertedCommand = commandLine.Trim().Split(' ');
            Assert.AreEqual(command.Excute(player, convertedCommand), gem.FullDescription);
        }
        [Test]
        public void TestLookAtGemInBag()
        {
            string commandLine = "look at darkgem in leatherbag";
            string[] convertedCommand = commandLine.Trim().Split(' ');
            Assert.AreEqual(command.Excute(player, convertedCommand), gem2.FullDescription);
        }
        [Test]  
        public void TestLookAtGemInNoBag()
        {
            string commandLine = "look at darkgem in leatherbag";
            string[] convertedCommand = commandLine.Trim().Split(' ');
            Assert.AreEqual(command.Excute(playerNothing, convertedCommand), "I can't find the leatherbag");
        }
        [Test]
        public void TestLookAtNoGemInBag()
        {
            string commandLine = "look at gem in emptybag";
            string[] convertedCommand = commandLine.Trim().Split(' ');
            Assert.AreEqual(command.Excute(playerNothing, convertedCommand), "I can't find the gem");
        }
        [Test]
        public void TestInvalidLook()
        {
            string commandLine = "look around";
            string[] convertedCommand = commandLine.Trim().Split(' ');
            Assert.AreEqual(command.Excute(playerNothing, convertedCommand), "I don't know how to look like that");

            commandLine = "look at bag in my inventory";
            convertedCommand = commandLine.Trim().Split(' ');
            Assert.AreEqual(command.Excute(playerNothing, convertedCommand), "I don't know how to look like that");



            commandLine = "hello";
            convertedCommand = commandLine.Trim().Split(' ');
            Assert.AreEqual(command.Excute(playerNothing, convertedCommand), "I don't know how to look like that");

            commandLine = "hello how you";
            convertedCommand = commandLine.Trim().Split(' ');
            Assert.AreEqual(command.Excute(playerNothing, convertedCommand), "Error in look input");

            commandLine = "look in gem";
            convertedCommand = commandLine.Trim().Split(' ');
            Assert.AreEqual(command.Excute(playerNothing, convertedCommand), "What do you want to look at?");

        }
    }
}