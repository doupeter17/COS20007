using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSemester1
{
    public class Folder : Thing
    {
        private List<Thing> _contents;
        private string _name;

        public Folder(string name) : base(name)
        {
            _name = name;
            _contents = new List<Thing>();
        }

        public void Add(Thing toAdd) 
        {
            _contents.Add(toAdd);
        }
        
        public override void Print()
        {
            if (_contents.Count != 0) 
            {
                Console.WriteLine($"The folder '{_name}' contains {this.Size()} bytes total:");
                foreach (Thing thing in _contents)
                {
                    thing.Print();
                }
            } else { Console.WriteLine($"The folder '{_name}' is empty!"); }
            
        }

        public override int Size()
        {
            
            int sumSize = 0;
            foreach (Thing thing in _contents)
            {
                sumSize += thing.Size();
            }
            return sumSize;
            
        }
       

        public string Name { get { return _name;} }

    }
}
