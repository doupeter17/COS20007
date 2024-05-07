using System;
using System.Xml;
using SplashKitSDK;
using SwinAdventure;

namespace Iteration5
{
    public class Program
    {
        public static void Main()
        {
            LookCommand lookCommand = new LookCommand();

            Console.WriteLine("Welcome summoner! Tell me your name");
            string playerName = Console.ReadLine();
            Console.WriteLine("Tell me more about your self");
            string playerDesc = Console.ReadLine();
            Player player1 = new Player(playerDesc, playerName);
            Console.WriteLine(player1.ShortDescription);


            Console.WriteLine("Congratulation!!! Now I will give you a Leather Bag, a Hat and a Metal Sword, use it wisely.");
            Bag bag = new Bag(new string[] { "bag" }, "Leather Bag", "Useful item for Beginner");
            Item swordlv1 = new Item(new string[] { "sword" }, "Metal Sword", "This sword can cut everything");
            Item hat = new Item(new string[] { "hat" }, "Handsome Hat", "This hat make you handsome :)");


            player1.Inventory.Put(bag);
            player1.Inventory.Put(swordlv1);
            player1.Inventory.Put(hat);


            Console.WriteLine("Luckily, you are my first player so I give you a Lucky Star item");
            Item star = new Item(new string[] { "star" }, "Lucky Star", "This medal will follow you");
            bag.Inventory.Put(star);


            while(true)
            {
                Console.WriteLine("Enter command:");
                string input = Console.ReadLine();
                string[] command = input.Split(new char[] {' '});

                string output = lookCommand.Excute(player1, command);
                Console.WriteLine(output);

            }

        }
    }
}
