using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSemester1
{

    public class File : Thing
    {
        private string _name;
        private string _extension;
        private int _size;

        public File(string name, string extension, int size) : base(name)
        {
            _name = name;
            _extension = extension;
            _size = size;
        }
        public override int Size()
        {
            return _size; 
        } 
        public override void Print()
        {
            Console.WriteLine($"File '{_name}.{_extension}' -- {_size} bytes");
        }
        public string Name { get { return _name;} }

    }

}
