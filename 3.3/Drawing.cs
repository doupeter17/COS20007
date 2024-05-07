using Lab3_3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;
using Lab3_3;
using System.ComponentModel;
namespace Lab2._3
{
    public class Drawing
    {
        private readonly List<Shape> _shapes;
        private Color _background;

        public Drawing(Color background)
        { 
            _shapes= new List<Shape>();
            _background= background;
        }
        public Drawing() : this(Color.White)
        {

        }
        public int ShapeCount { get { return _shapes.Count; } }
        public Color Background { get { return _background; } set { _background = value; } }
        public List<Shape> SelectedShape
        {
            get {
                List<Shape> selected = new List<Shape>();
                foreach (Shape shape in _shapes) {
                    if (shape.Selected == true) 
                    {
                        selected.Add(shape);
                    }
                }
                return selected;
            }
        }

        public void SelectShapesAt(Point2D pt)
        {
            foreach (Shape shape in _shapes)
            {
                if (shape.IsAt(pt))
                {
                    shape.Selected = true;
                }
                else 
                { 
                    shape.Selected = false; 
                }
            }
        }

        public void AddShape (Shape s) 
        {
            _shapes.Add(s);
        }
        public void RemoveShape()
        {
            List<Shape> remove = new List<Shape>();

            foreach (Shape shape in _shapes)
            {
                if (shape.Selected)
                {
                    remove.Add(shape);
                }
            }

            foreach (Shape shape in remove)
            {
                _shapes.Remove(shape);
            }
        }
        public void Draw()
        {
            SplashKit.ClearScreen(_background);
            foreach (Shape s in _shapes) { s.Draw(); }
        }
    }
}
