using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class Location : GameObject, IHaveInventory
    {
        Inventory _inventory = new Inventory();
        public Location(string[] ids, string name, string desc) : base(ids, name, desc)
        {
        }

        public GameObject Locate(string id)
        {
            if (this.AreYou(id) == true)
            {
                return this;
            }
            return _inventory.Fetch(id);
        }
        public override string FullDescription { get { return $"Location: {this.Name}.\nItem in here:\n{Inventory.itemList}"; } }
        public Inventory Inventory { get { return _inventory; } }
    }
}
