using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class Location : GameObject, IHaveInventory  
    {
        Inventory _inventory = new Inventory();
        List<Path> _listPath = new List<Path>();
        public Location(string[] ids, string name, string desc) : base(ids, name, desc)
        {
            
        }

        public GameObject Locate(string id)
        {
            if (AreYou(id))
            {
                return this;
            }

            foreach (Path path in _listPath)
            {
                if (path.AreYou(id))
                {
                    return path;
                }
            }

            return _inventory.Fetch(id);
        }
        public override string FullDescription { get { return $"Location: {this.Name}.\nItem in here:\n{Inventory.itemList}"; } }
        public Inventory Inventory { get { return _inventory; } }
        public string listPath
        {
            get
            {
                string displayItem = "";
                foreach (Path path in _listPath)
                {
                    displayItem += ("To go to "+path.Destination.Name+", move to "+path.Name+"\n");
                }
                return displayItem;
            }
        }

        public void AddPath(Path path)
        {
            _listPath.Add(path);
        }
    }
}
