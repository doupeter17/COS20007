using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iteration2
{
    public class GameObject : IdentifiableObject
    {
        private string _description;
        private string _name;

        public GameObject(string[] ids,string desc, string name) : base(ids)
        {
            _description = desc;
            _name = name;
        }

        public string Name
        {
            get { return _name; }
        } 
        public string ShortDescription { get { return "a "+ _name + " (" + FirstId + ")"; } }
        public virtual string FullDescription { get { return _description; } }
    }
}
