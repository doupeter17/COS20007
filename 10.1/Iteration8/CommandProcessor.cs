using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SwinAdventure
{
    public class CommandProcessor : Command
    {

        public CommandProcessor() : base(new string[] { "command" })
        {
            
        }

        public override string Excute(Player p, string[] text)
        {
            if (text.Length > 0)
            {
                if (text[0] == "look")
                {
                    LookCommand command = new LookCommand();
                    return command.Excute(p, text);

                }
                if (text[0] == "move")
                {
                    MoveCommand command = new MoveCommand();
                    return command.Excute(p, text);
                }
                return "Done";
            } 
            else
            {
                return "Invalid command";
            }
         
        }

  
    }
}
