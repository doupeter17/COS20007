    
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class Player : GameObject, IHaveInventory
    {
        Inventory _inventory = new Inventory();
        Location _location;
        public Player( string desc, string name) : base(new string[] {"me", "inventory"}, desc, name)
        {

        }
        public GameObject Locate(string id)
        {
            if (this.AreYou(id) == true)
            {
                return this;
            }
            GameObject obj = _inventory.Fetch(id);
            if (obj != null)
            {
                return obj;
            }
            if(this._location != null)
            {
                obj = _location.Locate(id);
                return obj;
            } 
            else
            {
                return null;
            }
        }
        public override string FullDescription { get { return $"You are {this.Name} {base.FullDescription}.\nYou are carrying\n{Inventory.itemList}"; } } 
        public Inventory Inventory { get { return _inventory; } }
        public Location Location { get { return _location; }  set { _location = value; } }
        public void Move(Path path)
        {
            if (path.Destination != null)
            {
                _location = path.Destination;
            }
        }
    }
}
