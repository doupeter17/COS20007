using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;
namespace ShapeDrawer
{
    public class MyRectangle : Shape
    {
        private int _width;
        private int _height;    
        public MyRectangle() : this(Color.Green, 0, 0, 100, 100) { }
        public MyRectangle(Color color, float x, float y, int height, int width) : base(color)
        {
            Width = width;
            Height = height;
            X = x;
            Y = y;
        }
        public int Width { get { return _width; }  set { _width = value; } }
        public int Height { get { return _height; } set { _height = value; } }
        public override void Draw()
        {
            if (Selected)
            {
                DrawOutline();
            }
            SplashKit.FillRectangle(Color, X, Y, Width, Height);
        }
        public override void DrawOutline()
        {
            SplashKit.FillRectangle(Color.Black, X-2, Y-2, _width + 4, _height + 4);
        }

        public override bool IsAt(Point2D pt)
        {
            return SplashKit.PointInRectangle(pt, SplashKit.RectangleFrom(X, Y , Width, Height));
        }
    }
    
}
