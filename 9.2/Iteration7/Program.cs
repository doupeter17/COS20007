using System;
using SplashKitSDK;

namespace SwinAdventure
{
    public class Program
    {
        public static void Main()
        {
            Player? playerTest;
            Location? room1;
            Location? room2;
            SwinAdventure.Path? pathTest;
            MoveCommand? moveCommand;
            playerTest = new Player("Thanh", "Handsome player");

            room1 = new Location(new string[] { "Room 1" }, "Room 1", "This is room 1");
            room2 = new Location(new string[] { "Room 2" }, "Room 2", "This is room 2");

            playerTest.Location = room1;
            pathTest = new SwinAdventure.Path(new string[] { "south" }, "south", "Go from room 1 to room 2", room1, room2);
            room1.AddPath(pathTest);

            moveCommand = new MoveCommand(new string[] { "move" });
            moveCommand.Excute(playerTest, new string[] { "move", "south" });
            Console.WriteLine(room1.listPath);
        }
    }
}
