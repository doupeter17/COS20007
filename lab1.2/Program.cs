using HelloWorld1;
using System;

namespace HelloWorld
{ 
    class MainClass

    {
        public static void Main(string[] args)
        {
            
            Message[] message = new Message[5];
            message[0] = new Message("Welcome back!");
            message[1] = new Message("What a lovely name");
            message[2] = new Message("Great name");
            message[3] = new Message("Oh hi!");
            message[4] = new Message("That is a silly name");
            for (int i = 0; i < 5; i++) {
                Console.WriteLine("What your name?");
                string name= Console.ReadLine();
                if (name.ToLower() == "thanh") {
                    message[0].Print();
                } else if (name.ToLower() == "duong")
                {
                    message[1].Print();
                }
                else if (name.ToLower() == "phuc")
                {
                    message[2].Print();
                }
                else if (name.ToLower() == "cuong")
                {
                    message[3].Print();
                }
                else 
                {
                    message[4].Print();
                }
            }
            Console.ReadLine();
        }
    }
}