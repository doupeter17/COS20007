using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class IdentifiableObject
    {
        private List<string> _identifiers;
        public IdentifiableObject(string[] identify)
        {

            _identifiers = new List<string>(identify.Length);
            foreach (string id in identify)
            {
                _identifiers.Add(id.ToLower());
            }
        }
        public bool AreYou(string id)
        {

            return _identifiers.Contains(id.ToLower());
        }

        public string FirstId
        {
            get
            {
                if (_identifiers.Count == 0)
                {
                    return "";
                }
                else
                {
                    return _identifiers[0];
                }

            }
        }

        public void AddIdentifier(string id)
        {

            _identifiers.Add(id.ToLower());
        }
    }
}
