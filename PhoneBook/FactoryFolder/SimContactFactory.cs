using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneBook.SingletonFolder;

namespace PhoneBook.FactoryFolder
{
    internal class SimContactFactory:ContactFactory
    {
        public override Contact CreatContact(string name, string phoneNumber, ContactGroup group, Dictionary<string, object> attributes)
        {
            var contact = new SimContact(name, phoneNumber, group, attributes);
            DisplayContact.Printer.Print(contact, "Created in sim Contact Factory");
            return contact;
        }
    }
}
