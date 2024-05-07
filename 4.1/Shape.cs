using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeDrawer
{
    public abstract class Shape
    {
        private Color _color;
        private float _x;
        private float _y;
        private float Width;
        private float Height;

        private bool _selected;
        public Shape(Color color)
        {
            Width = 100;
            Height = 100;
            Color = Color.Yellow;
        }
        
        public float X
        {
            get
            {
                return _x;
            }
            set
            {
                _x = value;
            }
        }
        public float Y
        {
            get
            {
                return _y;
            }
            set
            {
                _y = value;
            }
        }
        public Color Color
        {
            get
            {
                return _color;
            }
            set
            {
                _color = value;
            }
        }
        public bool Selected
        {
            get
            {
                return _selected;
            }
            set
            {
                _selected = value;
            }
        }
        public abstract void Draw();
        


        public abstract bool IsAt(Point2D pt);
       


        public abstract void DrawOutline();
        
    }
    
}
