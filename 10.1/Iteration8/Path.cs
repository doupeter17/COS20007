    
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
	
    public class Path : GameObject
    {
        Location _source, _destination;
        bool _isLocked;
        public Path(string[] ids, string name, string desc, Location source, Location destination) : base(ids, name, desc)
        {
            _source = source;
            _destination = destination;
            _isLocked = false;
        }
        public override string FullDescription
        {
            get
            {
                return Name;
            }
        }
        public Location Destination { get { return _destination; } }
        public Location Source { get { return _source; } }
        public bool IsLocked { get { return _isLocked; } set { _isLocked = value; } }

    }
	
	
}
