using System;
using SplashKitSDK;

namespace SwinAdventure
{
    public class Program
    {
        public static void Main()
        {
            LookCommand command = new LookCommand();
            Player player = new Player("A handsome guy","Thanh");
            string commandLine = "look at gem in bag";
            string[] convertedCommand = commandLine.Trim().Split(' ');
            command.Excute(player, convertedCommand);
            Console.ReadLine(); 
        }
    }
}
