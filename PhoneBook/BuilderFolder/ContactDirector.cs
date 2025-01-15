using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.BuilderFolder
{
    internal class ContactDirector
    {


       ContactBuilder builder;
        public ContactDirector(ContactBuilder _builder)
        {
            builder = _builder;
        }

        public void ChangeBuilder(ContactBuilder _builder)
        {
            builder = _builder;

        }

        public void ColorEmailContact(string name,string phoneNumber,ContactGroup group)
        {
            builder.Reset(name,phoneNumber,group);
            builder.AddColor(Colors.Red);
            builder.AddEmailAddress("r@gmail.com");

        }

        public void ColorRingtoneContact(string name, string phoneNumber, ContactGroup group)
        {
            builder.Reset(name, phoneNumber, group);
            builder.AddColor(Colors.Red);
            builder.AddRingtone("always loves me");
        }


    }
}
