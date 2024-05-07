using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class MoveCommand : Command
    {
        public MoveCommand() : base(new string[] {"movecommand"})
        {
        }

        public override string Excute(Player p, string[] text)
        {
            
            string _destination;
            if (text[0] == "move")
            {
                switch (text.Length)
                {
                    case 1:
                        return "Move where?";

                    case 2:
                        _destination = text[1].ToLower();
                        break;

                    case 3:
                        _destination = text[2].ToLower();
                        break;

                    default:
                        return "Please follow this example commmand 'move to Valhalla'";
                }

                GameObject _path = p.Location.Locate(_destination);
                if (_path != null)
                {
                    if (_path.GetType() != typeof(Path))
                    {
                        return "Could not find the " + _path.Name;
                    }
                    p.Move((Path)_path);
                    return "You have moved " + _path.FirstId + " through a " + _path.Name + " to the " + p.Location.Name + ".\r\n\n" + p.Location.FullDescription;
                }
                else
                    return "Path not found";
            } 
            else
            {
                return "Invalid command!";
            }
        }
    }
}
