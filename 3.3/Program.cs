using SplashKitSDK;
using Lab3_3;
using Lab2._3;
namespace Lab3_3
{
    public class Program
    {
        public static void Main()
        {
            Drawing drawing = new Drawing();
            Window window = new Window("Shape Drawer", 800, 600);

            do
            {
                SplashKit.ProcessEvents();

                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    // Get the mouse position when clicked
                    float mouseX = SplashKit.MouseX();
                    float mouseY = SplashKit.MouseY();
                    Shape shape = new Shape(mouseX, mouseY);
                    drawing.AddShape(shape);
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