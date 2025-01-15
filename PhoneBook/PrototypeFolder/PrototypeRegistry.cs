using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Xml.Linq;
using PhoneBook.SingletonFolder;

namespace PhoneBook.PrototypeFolder
{
    
    internal class PrototypeRegistry
    {
        private readonly Dictionary<ContactGroup, IPrototype> prototypes;

        public PrototypeRegistry()
        {
            prototypes = new Dictionary<ContactGroup, IPrototype>();
        }

        public void AddPrototype(ContactGroup group, IPrototype prototype)
        {
            prototypes[group] = prototype;
        }

        public IPrototype GetPrototype(ContactGroup group)
        {
            if (prototypes.TryGetValue(group, out var prototype))
            {
                PhoneContact contact = (PhoneContact)prototype.Clone();
                DisplayContact.Printer.Print(contact, $"Created in prototype{group} Contact Builder");
                return contact;
            }
            throw new KeyNotFoundException($"Prototype for group '{group}' does not exist.");
        }
    }
}

