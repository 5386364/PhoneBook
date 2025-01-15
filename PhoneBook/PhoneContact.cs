using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneBook.PrototypeFolder;

namespace PhoneBook
{
    internal class PhoneContact : Contact,IPrototype
    {
        public PhoneContact(string name, string phoneNumber, ContactGroup group, Dictionary<string, object> attributes) : base(name, phoneNumber, group, attributes)
        {
        }
        public PhoneContact(string name, string phoneNumber ,ContactGroup group) : base(name, phoneNumber, group, new Dictionary<string, object> ())
        {

        }
        public PhoneContact(PhoneContact phone):base(phone) 
        {

        }

        public PhoneContact(ContactGroup group) : base(group)
        {
        }

        public IPrototype Clone()
        {
            return new PhoneContact(this);
        }
    }
}
