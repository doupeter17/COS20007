using System;
using SplashKitSDK;

namespace ShapeDrawer
{
    public class Program
    {
        
        private enum ShapeKind
        {
            Rectangle, Circle, Line
        }
        public static void Main()
        {
            Drawing drawing = new Drawing();
            Window window = new Window("Shape Drawer", 800, 600);
            ShapeKind kindToAdd = ShapeKind.Circle;
            do
            {
                SplashKit.ProcessEvents();

                // Setting keyboard to change the shape kind
                if (SplashKit.KeyDown(KeyCode.RKey))
                {
                    kindToAdd = ShapeKind.Rectangle;
                }
                if (SplashKit.KeyDown(KeyCode.CKey))
                {
                    kindToAdd = ShapeKind.Circle;
                }
                if (SplashKit.KeyDown(KeyCode.LKey))
                {
                    kindToAdd = ShapeKind.Line;
                }

                
                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    if(kindToAdd == ShapeKind.Rectangle)
                    {
                        MyRectangle newRect = new MyRectangle();
                        newRect.X = SplashKit.MouseX();
                        newRect.Y = SplashKit.MouseY();
                        drawing.AddShape(newRect);
                    }
                    if(kindToAdd == ShapeKind.Circle)
                    {
                        MyCircle myCircle = new MyCircle();
                        myCircle.X = SplashKit.MouseX();
                        myCircle.Y = SplashKit.MouseY();
                        myCircle.Radius = 50;
                        drawing.AddShape(myCircle);

                    }
                    if (kindToAdd == ShapeKind.Line)
                    {
                        MyLine myLine = new MyLine();
                        myLine.X = SplashKit.MouseX();
                        myLine.Y = SplashKit.MouseY();
                        myLine.Length = 100;
                        drawing.AddShape(myLine);

                    }
                    
                }
                if (SplashKit.KeyDown(KeyCode.SKey))
                {
                    drawing.Save("C:\\Users\\ntuan\\OneDrive - MSFT\\Swinburne Course\\COS20007\\COS20007\\5.3\\TestDrawing.txt");
                }

                if (SplashKit.KeyDown(KeyCode.OKey))
                {
                    try
                    {
                        drawing.Load("C:\\Users\\ntuan\\OneDrive - MSFT\\Swinburne Course\\COS20007\\COS20007\\5.3\\TestDrawing.txt");
                    }
                    catch (Exception e)
                    {
                        Console.Error.WriteLine($"Error loading file: {0}", e.Message);
                    }
                }

                // Check if the mouse is over the shape and the spacebar is pressed
                if (SplashKit.KeyTyped(KeyCode.SpaceKey))
                {
                    drawing.Background = SplashKit.RandomRGBColor(255);
                    // Change the color of the shape to a random color
                }
                if (SplashKit.MouseClicked(MouseButton.RightButton))
                {
                    drawing.SelectShapesAt(SplashKit.MousePosition());
                }
                if (SplashKit.KeyTyped(KeyCode.BackspaceKey)|| SplashKit.KeyTyped(KeyCode.DeleteKey))
                {
                    drawing.RemoveShape();
                }
                // Clear the screen
                SplashKit.ClearScreen();

                // Draw your game objects here
                drawing.Draw();

                // Update the screen
                SplashKit.RefreshScreen();

            } while (!window.CloseRequested);
        }
        
    }
   
}

