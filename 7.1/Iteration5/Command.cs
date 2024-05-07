using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public abstract class Command : IdentifiableObject
    {
        public Command(string[] identify) : base(identify)
        {
        }
        public abstract string Excute(Player p, string[] text);
        
    }
}
