using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook
{
    internal abstract class Contact
    {
       
            public string Name { get; set; }
            public string PhoneNumber { get; set; }
            public ContactGroup Group { get; set; }
            public Dictionary<string, object> Attributes { get; set; } = new Dictionary<string, object>();

            
            public Contact(string name, string phoneNumber, ContactGroup group, Dictionary<string, object> attributes)
            {
                Name = name;
                PhoneNumber = phoneNumber;
                Group = group;
                Attributes = attributes;
            }


        public Contact(Contact contact)
        {
            Name = contact.Name;
            PhoneNumber = contact.PhoneNumber;
            Group = contact.Group;
            Attributes = contact.Attributes;
        }

        public Contact(ContactGroup group)
        {
            Group = group;
        }


        public override string ToString()
            {
                string s = $"{"Name",-15}: {Name,-15} \n{"Phone Number",-15}: {PhoneNumber,-15} \n{"Group",-15}: {Group,-15}\n";
                
                foreach (var item in Attributes)
                {
                s += $"{item.Key,-15}: {item.Value,-15}\n";
                }
                  return s;
            }
    }

    }

