using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeDrawer
{
    public class MyCircle : Shape
    {
        private int _radius;
        public MyCircle() : this(Color.Blue, 0, 0, 50) { }
        public MyCircle(Color color, int x, int y, int radius) : base(color)
        {
            Radius = radius;
            X= x; Y= y;
            Color = color;
        }
        public int Radius
        {
            get { return _radius; }
            set { _radius = value; }
        }

        public override void Draw()
        {
            if(Selected)
            {
                DrawOutline();
            }
            SplashKit.FillCircle(Color, X, Y, Radius);
        }

        public override void DrawOutline()
        {
            SplashKit.FillCircle(Color.Black, X, Y, Radius+2);
        }

        public override bool IsAt(Point2D pt)
        {
            return SplashKit.PointInCircle(pt, SplashKit.CircleAt(X, Y, Radius));
        }
        public override void SaveTo(StreamWriter writer)
        {
            writer.WriteLine("Circle");
            base.SaveTo(writer);
            writer.WriteLine(Radius);
        }
        public override void LoadFrom(StreamReader reader)
        {
            base.LoadFrom(reader);
            _radius = reader.ReadInteger();
        }
    }
}
