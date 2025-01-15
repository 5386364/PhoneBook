using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.FactoryFolder
{
    internal  abstract class ContactFactory
    {
        public abstract Contact CreatContact(string name, string phoneNumber, ContactGroup group, Dictionary<string, object> attributes);
    }
}
