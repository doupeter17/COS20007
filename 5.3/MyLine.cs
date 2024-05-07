using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeDrawer
{
    public class MyLine : Shape
    {
        private int _length;

        public MyLine(Color color, int length ) : base(color)
        {
            _length = length;
        }
        public MyLine() : this(Color.RandomRGB(255), 100) { }
        public int Length { get { return _length; }  set { _length = value; } }
        public override void Draw()
        {
            if (Selected)
            {
                DrawOutline();
            }
            SplashKit.DrawLine(Color, X, Y, _length+X, Y);
        }

        public override void DrawOutline()
        {
            SplashKit.FillRectangle(Color.Black, X-2, Y-2, Length+4, 5);
        }

        public override bool IsAt(Point2D pt)
        {
            return SplashKit.PointOnLine(pt, SplashKit.LineFrom(X, Y, _length + X, Y));
        }
        public override void SaveTo(StreamWriter writer)
        {
            writer.WriteLine("Line");
            base.SaveTo(writer);
            writer.WriteLine(Length);

        }
        public override void LoadFrom(StreamReader reader)
        {
            base.LoadFrom(reader);
            _length = reader.ReadInteger();
        }
    }
}
