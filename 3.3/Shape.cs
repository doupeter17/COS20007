using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2._3
{
    public class Shape
    {
        public Color Color { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
        private float Width { get; }
        private float Height { get; }

        private bool _selected;
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
            if (_selected)
            {
                DrawOutline();
            }
        }

        public bool IsAt(Point2D pt)
        {
            // Check if the point is within the bounds of the shape
            return pt.X >= X && pt.X <= X + Width && pt.Y >= Y && pt.Y <= Y + Height;
        }
        public bool Selected
        {
            get {
                return _selected;
            } 
            set {
                _selected = value;
            }
        }
        public void DrawOutline() 
        {
            
                SplashKit.DrawRectangle(Color.Black, X-2, Y-2, Width +4, Height + 4);
            
        }
    }
    
}
