using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneBook.PrototypeFolder;

namespace PhoneBook
{
    internal class SimContact : Contact,IPrototype 
    {
        public SimContact(string name, string phoneNumber, ContactGroup group, Dictionary<string, object> attributes) : base(name, phoneNumber, ContactGroup.General, attributes)
        {
            Attributes["Color"] = Colors.DarkGray;
        }
        public SimContact(string name, string phoneNumber) : base(name, phoneNumber, ContactGroup.General, new Dictionary<string, object>())
        {
            Attributes["Color"] = Colors.DarkGray;
        }

        public SimContact(SimContact phone) : base(phone)
        {

        }

        public IPrototype Clone()
        {
            return new SimContact(this);
        }
    }
}
