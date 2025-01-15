using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneBook.FactoryFolder;

namespace PhoneBook
{
    internal class ContactsList
    {
        List<Contact> phoneBooklist = new List<Contact>();
        public void AddPhoneNumber(ContactFactory creator,string name, string phoneNumber, ContactGroup group, Dictionary<string, object> attributes)
        {
            phoneBooklist.Add(creator.CreatContact(name, phoneNumber, group, attributes));
        }
        public void AddPhoneNumber(Contact phoneBook)
        {
            phoneBooklist.Add(phoneBook);
        }

        public Contact GetPhoneNumberByName(string name) { 
        return phoneBooklist.First(p => p.Name == name);
        }

        public Contact GetPhoneNumberByNumber(string number) {
            return phoneBooklist.First(p => p.PhoneNumber == number);
        }

        public List<Contact> GetAllContacts()
        {
            return phoneBooklist;
        }

    }
}
