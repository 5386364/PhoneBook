using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.BuilderFolder
{
    internal interface ContactBuilder
    {

        public void Reset(string name, string phoneNumber,ContactGroup group);

        public void AddBirthday(DateTime birthday);
        public void AddColor(Colors color);
        public void AddRingtone(string ringtone);
        public void AddEmailAddress(string email);

    }
}
