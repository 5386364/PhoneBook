using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneBook.SingletonFolder;

namespace PhoneBook.BuilderFolder
{
    internal class SimContactBuilder : ContactBuilder
    {
        SimContact simContact;
        public void Reset(string name, string phoneNumber, ContactGroup group)
        {
            simContact=new SimContact(name, phoneNumber);
        }
       

        public void AddBirthday(DateTime birthday)
        {
            simContact.Attributes["BirthDay"]=birthday;

        }

        public void AddColor(Colors color)
        {
            simContact.Attributes["Color"] = Colors.DarkGray;
        }

        public void AddEmailAddress(string email)
        {
            simContact.Attributes["Email"]=email;
        }

        public void AddRingtone(string ringtone)
        {
            simContact.Attributes["Rington"]=ringtone;
        }

        public SimContact GetSimContact()
        {
            DisplayContact.Printer.Print(simContact, "Created in Sim Contact Builder");

            return simContact;
        }
    }
}
