using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneBook.SingletonFolder;

namespace PhoneBook.BuilderFolder
{
    internal class PhoneContactBuilder : ContactBuilder

    {
        PhoneContact phoneContact;
        public void Reset(string name, string phoneNumber, ContactGroup group)
        {
            phoneContact = new PhoneContact(name, phoneNumber, group);


        }
        public void AddBirthday(DateTime birthday)
        {
            phoneContact.Attributes["BirthDay"] = birthday;
        }

        public void AddColor(Colors color)
        {
            phoneContact.Attributes["Color"] = color;
        }

        public void AddEmailAddress(string email)
        {
            phoneContact.Attributes["Email"] = email;
        }

        public void AddRingtone(string ringtone)
        {
            phoneContact.Attributes["Rington"] = ringtone;
        }

        public PhoneContact GetPhoneContact()
        {
            DisplayContact.Printer.Print(phoneContact, "Created in phone Contact Builder");
            return phoneContact;
        }
    }
}
