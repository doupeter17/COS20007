using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class Player : GameObject
    {
        Inventory _inventory = new Inventory();
        public Player( string desc, string name) : base(new string[] {"me", "inventory"}, desc, name)
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
        public override string FullDescription { get { return $"You are {Name} {base.FullDescription}.\nYou are carrying\n{Inventory.itemList}"; } } 
        public Inventory Inventory { get { return _inventory; } }
    }
}
