using SwinAdventure;
namespace CommandProcessorTest
{
    public class Tests
    {
        Player? playerTest;
        Location? room1;
        Location? room2;
        SwinAdventure.Path? pathTest;
        CommandProcessor? command;
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void TestMoveCommand()
        {
            playerTest = new Player("Thanh", "Handsome player");

            room1 = new Location(new string[] { "Room 1" }, "Room 1", "This is room 1");
            room2 = new Location(new string[] { "Room 2" }, "Room 2", "This is room 2");

            playerTest.Location = room1;
            pathTest = new SwinAdventure.Path(new string[] { "south" }, "south", "just a path", room1, room2);
            room1.AddPath(pathTest);

            command = new CommandProcessor();
            command.Excute(playerTest, new string[] { "move", "south" });
            Assert.AreEqual(playerTest.Location, room2);
        }
        [Test]
        public void TestLookCommand()
        {
            playerTest = new Player("Thanh", "Handsome player");
            Item sword = new Item(new string[] { "sword" }, "Sword", "Sharp");

            playerTest.Inventory.Put(sword);


            command = new CommandProcessor();
            command.Excute(playerTest, new string[] { "look", "at", "sword" });
            Assert.AreEqual(command.Excute(playerTest, new string[] { "look", "at", "sword" }), sword.FullDescription);
        }
    }
}