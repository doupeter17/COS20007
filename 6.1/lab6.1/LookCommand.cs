using lab6._1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class LookCommand : Command
    {
        IHaveInventory container;
        public LookCommand() : base(new string[] {"lookcommand"})
        {

        }

        public override string Excute(Player p, string[] text)
        {
            string itemID;
            if ((text.Length == 3) || (text.Length == 5))
            { 
                if (text[0] != "look")
                {
                    return "Error in look input";
                }
                else
                {
                    if (text[1] != "at")
                    {
                        return "What do you want to look at?";
                    }
                    else
                    {
                        if(text.Length == 3)
                        { 
                            container = p;      
                        }
                        if (text.Length == 5)
                        {
                            container = FetchContainer(p, text[4]);
                            if (container == null)
                            {
                                
                            }
                        }
                        if (container == null)
                        {
                            itemID = text[4];
                        } else
                        { itemID = text[2]; }
                        
                    }
                }
            } else
            {
                return "I don't know how to look like that";
            }
            return LookAtIn(itemID, container);
        }
        private IHaveInventory FetchContainer(Player p, string containerId)
        {
            return (IHaveInventory)p.Locate(containerId);
        }
        private string LookAtIn(string thingId, IHaveInventory container)
        {
            if (container != null)
            {
                if (container.Locate(thingId) != null)
                {
                    return container.Locate(thingId).FullDescription;
                }
            }
            return "I can't find the " + thingId; 
        }
    }
}
