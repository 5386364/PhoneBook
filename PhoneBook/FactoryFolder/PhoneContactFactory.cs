using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneBook.SingletonFolder;

namespace PhoneBook.FactoryFolder
{
    internal class PhoneContactFactory:ContactFactory
    {

        public override Contact CreatContact(string name, string phoneNumber, ContactGroup group, Dictionary<string, object> attributes)
        {
            var contact = new PhoneContact(name, phoneNumber, group, attributes);
            DisplayContact.Printer.Print(contact, "Created in Phone Contact Factory");

            return contact;
        }
    }
}
