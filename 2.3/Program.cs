using SplashKitSDK;

namespace Lab2_3
{
    public class Program
    {
        public static void Main()
        {
            Shape myShape = new Shape(0, 0);
            Window window = new Window("Shape Drawer", 800, 600);

            do
            {
                SplashKit.ProcessEvents();

                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    // Get the mouse position when clicked
                    float mouseX = SplashKit.MouseX();
                    float mouseY = SplashKit.MouseY();
                    myShape.X = mouseX;
                    myShape.Y = mouseY;
                }

                // Check if the mouse is over the shape and the spacebar is pressed
                if (SplashKit.KeyTyped(KeyCode.SpaceKey) && myShape.IsAt(SplashKit.MousePosition()))
                {
                    // Change the color of the shape to a random color
                    myShape.Color = SplashKit.RandomRGBColor(255);
                }

                // Clear the screen
                SplashKit.ClearScreen();

                // Draw your game objects here
                myShape.Draw();

                // Update the screen
                SplashKit.RefreshScreen();

            } while (!window.CloseRequested);
        }
    }

    public class Shape
    {
        public Color Color { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
        private float Width { get; }
        private float Height { get; }

        public Shape(float x, float y)
        {
            X = x;
            Y = y;
            Width = 100;
            Height = 100;
            Color = Color.Green;
        }

        public void Draw()
        {
            SplashKit.FillRectangle(Color, X, Y, Width, Height);
        }

        public bool IsAt(Point2D pt)
        {
            // Check if the point is within the bounds of the shape
            return pt.X >= X && pt.X <= X + Width && pt.Y >= Y && pt.Y <= Y + Height;
        }
    }
}