
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

using System.ComponentModel;
using System.Reflection.PortableExecutable;
namespace ShapeDrawer
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
        StreamWriter writer;
        
        public void Save(string filename)
        {
            writer = new StreamWriter(filename);
            try
            {
                writer.WriteColor(Background);
                writer.WriteLine(ShapeCount);

                foreach (Shape s in _shapes)
                {
                    s.SaveTo(writer);
                }
            }
            finally { writer.Close(); }
        }
        StreamReader reader;
        public void Load(string filename)
        {
            Shape s;
            string kind;
            reader = new StreamReader(filename);

            Background = reader.ReadColor();
            int count = reader.ReadInteger();
            _shapes.Clear();

            try
            {
                for (int i = 0; i < count; i++)
                {
                    kind = reader.ReadLine();
                    switch (kind)
                    {
                        case "Rectangle":
                            s = new MyRectangle();
                            break;
                        case "Circle":
                            s = new MyCircle();
                            break;
                        case "Line":
                            s = new MyLine();
                            break;
                        default:
                            throw new InvalidDataException("Unknown shape kind: " + kind);
                    }

                    s.LoadFrom(reader);
                    AddShape(s);
                }
            }

            finally
            {
                reader.Close();
            }

        }
    }
}
