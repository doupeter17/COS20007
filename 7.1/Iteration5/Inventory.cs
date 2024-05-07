using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class Inventory 
    {
        private List<Item> _items = new List<Item>(); 
        public Inventory()
        {

        }

        public bool HasItem (string id)
        {
            foreach (Item item in _items)
            {
                if (item.AreYou(id))
                {
                    return true;
                }
            }
            return false;
        }
        public void Put(Item itm)
        {
            _items.Add(itm);
        }
        public Item Take(string id)
        {
            foreach (Item itm in _items)
            {
                if(Fetch(id) != null)
                {
                    _items.Remove(itm);
                    return itm;
                }
            }
            return null;
        }
        public Item Fetch(string id) 
        { 
            foreach (Item itm in _items)
            {

                if (itm.AreYou(id))
                {
                    return itm;
                }
                
            }
            return null;

        }
        public string itemList 
        { 
            get
            {
                string displayItem = "";
                foreach (Item itm in _items)
                {
                    displayItem += ( "a "+itm.Name + " (" +itm.FirstId + ")\n");
                }
                return displayItem;
            } 
        } 
    }
}
