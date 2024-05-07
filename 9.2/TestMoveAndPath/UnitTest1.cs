using SwinAdventure;
namespace TestMoveAndPath
{
    public class Tests
    {
        Player? playerTest;
        Location? room1;
        Location? room2;
        SwinAdventure.Path? pathTest;
        MoveCommand? moveCommand;
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestMoveToDestination()
        {
            playerTest = new Player("Thanh", "Handsome player");

            room1 = new Location(new string[] { "Room 1" }, "Room 1", "This is room 1");
            room2 = new Location(new string[] { "Room 2" }, "Room 2", "This is room 2");

            playerTest.Location = room1;
            pathTest = new SwinAdventure.Path(new string[] { "south" }, "south", "just a path", room1, room2);
            room1.AddPath(pathTest);

            moveCommand = new MoveCommand(new string[] { "move" });
            moveCommand.Excute(playerTest, new string[] { "move", "south" });
            Assert.AreEqual(playerTest.Location.Name, room2.Name);
        }
        [Test]
        public void TestGetPath()
        {
            playerTest = new Player("Thanh", "Handsome player");

            room1 = new Location(new string[] { "Room 1" }, "Room 1", "This is room 1");
            room2 = new Location(new string[] { "Room 2" }, "Room 2", "This is room 2");

            playerTest.Location = room1;
            pathTest = new SwinAdventure.Path(new string[] { "south" }, "south", "just a path", room1, room2);
            room1.AddPath(pathTest);

            
            Assert.AreEqual(room1.listPath, "To go to Room 2, move to south\n");
        }
        [Test]
        public void TestInvalidPath()
        {
            playerTest = new Player("Thanh", "Handsome player");

            room1 = new Location(new string[] { "Room 1" }, "Room 1", "This is room 1");
            room2 = new Location(new string[] { "Room 2" }, "Room 2", "This is room 2");

            playerTest.Location = room1;
            pathTest = new SwinAdventure.Path(new string[] { "south" }, "south", "just a path", room1, room2);
            room1.AddPath(pathTest);

            moveCommand = new MoveCommand(new string[] { "move" });
            moveCommand.Excute(playerTest, new string[] { "move", "north" });
            Assert.AreEqual(moveCommand.Excute(playerTest, new string[] { "move", "north" }),"Path not found");
        }
    }
}