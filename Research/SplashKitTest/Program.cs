// SplashKit Example with Performance Measurement

using SplashKitSDK;
using System;

class Program
{
    static void Main()
    {
        SplashKit.OpenWindow("SplashKit Animation", 800, 600);
        

        var stopwatch = new System.Diagnostics.Stopwatch();
        stopwatch.Start();

        while (!SplashKit.WindowCloseRequested("SplashKit Animation"))
        {
            SplashKit.ClearScreen();

            for (int i = 0; i < 100; i++)
            {
                Random rand = new Random();
                double circleX = rand.Next(1, 35) * 10; // Random x-coordinate
                double circleY = rand.Next(1, 35) * 10; // Random y-coordinate
                double radius = 50; // You can adjust the radius as needed

                // Draw the circle
                SplashKit.DrawCircle(Color.Red, circleX, circleY, radius);
                Console.WriteLine(i);

            }

            SplashKit.CloseAllWindows();
            SplashKit.Delay(100);
        }

        stopwatch.Stop();
        Console.WriteLine($"Elapsed time: {stopwatch.ElapsedMilliseconds} ms");

        SplashKit.CloseWindow("SplashKit Animation");
    }
}
