using PhoneBook.FactoryFolder;
using PhoneBook;
using System.Net.Mail;
using PhoneBook.BuilderFolder;
using PhoneBook.PrototypeFolder;
using System.Security.AccessControl;
using PhoneBook.SingletonFolder;

internal class Program()
{
    private static void Main(string[] args)
    {
        ContactsList contacts = new ContactsList();
        contacts.AddPhoneNumber(new PhoneContactFactory(), "Sara", "0504126504", ContactGroup.Work, new Dictionary<string, object> { { "MailAddress", "r@gmail.com" }, { "Color", Colors.Cyan } });
        contacts.AddPhoneNumber(new SimContactFactory(), "Tamar", "0556750656", ContactGroup.General, new Dictionary<string, object> { { "Color", Colors.DarkGray } });
        

        PhoneContactBuilder phoneContactBuilder = new PhoneContactBuilder();
        phoneContactBuilder.Reset("Ruchama", "0534104273", ContactGroup.Friends);
        phoneContactBuilder.AddColor(Colors.Yellow);
        phoneContactBuilder.AddBirthday(new DateTime(2005, 3, 7));
        phoneContactBuilder.AddRingtone("pop");
        phoneContactBuilder.AddEmailAddress("r@gmail.com");
        PhoneContact contactPhone=phoneContactBuilder.GetPhoneContact();
        contacts.AddPhoneNumber(contactPhone);

        //למרות שהוספנו לסים הוא לא יקבל את הפיצרים שהוא לא יכול לקבל
        SimContactBuilder simContactBuilder = new SimContactBuilder();
        simContactBuilder.Reset("Michal", "0534104273", ContactGroup.Friends);
        simContactBuilder.AddColor(Colors.Yellow);
        simContactBuilder.AddBirthday(new DateTime(2005, 3, 7));
        simContactBuilder.AddRingtone("pop");
        simContactBuilder.AddEmailAddress("r@gmail.com");
        SimContact contactSim = simContactBuilder.GetSimContact();
        contacts.AddPhoneNumber(contactSim);


        ContactDirector director= new ContactDirector(phoneContactBuilder);
        director.ColorRingtoneContact("Miri","0527129133",ContactGroup.Friends);
        PhoneContact phoneContact=phoneContactBuilder.GetPhoneContact();
        phoneContact.Attributes.Add("Email", "r@gmail.com");
        contacts.AddPhoneNumber(phoneContact);



        director.ChangeBuilder(simContactBuilder);
        director.ColorEmailContact("Shira","0556750657",ContactGroup.General);
        contacts.AddPhoneNumber(simContactBuilder.GetSimContact());


        PrototypeRegistry registry = new PrototypeRegistry();

        var familyPrototype = new PhoneContact("Prototype_Family", "000", ContactGroup.Family);
        familyPrototype.Attributes["Birthday"] = null;
        familyPrototype.Attributes["Color"] = Colors.Blue;

        var friendsPrototype = new PhoneContact("Prototype_Friends", "000", ContactGroup.Friends);
        friendsPrototype.Attributes["Color"] = Colors.Green;
        friendsPrototype.Attributes["Rington"] = "Jaz";

        var workPrototype = new PhoneContact("Prototype_Work", "000", ContactGroup.Work);
        workPrototype.Attributes["Email"] = null;
        workPrototype.Attributes["Color"] = Colors.Cyan;

        registry.AddPrototype(ContactGroup.Family, familyPrototype);
        registry.AddPrototype(ContactGroup.Friends, friendsPrototype);
        registry.AddPrototype(ContactGroup.Work, workPrototype);

        PhoneContact familyContact = (PhoneContact)registry.GetPrototype(ContactGroup.Family);
        familyContact.Name = "John Doe";
        familyContact.PhoneNumber = "123456789";
        familyContact.Attributes["DataOfBirth"] = new DateTime(1990, 5, 15);
        contacts.AddPhoneNumber((PhoneContact)familyContact);

        while (true)
        {
            Console.WriteLine("\n--- Phonebook Menu ---");
            Console.WriteLine("1. Search contact by name");
            Console.WriteLine("2. Search contact by phone number");
            Console.WriteLine("3.display all contacts");
            Console.Write("Enter your choice (1,2 or 3): ");
            string choice = Console.ReadLine();
            Contact found;
            if (choice == "1")
            {
                Console.Write("Enter the name to search: ");
                string name = Console.ReadLine();
                found = contacts.GetPhoneNumberByName(name);
                DisplayContact.Printer.Print(found, "Contact details found by phone number:");
                break;
            }
            else if (choice == "2")
            {
                Console.Write("Enter the phone number to search: ");
                string phoneNumber = Console.ReadLine();
                found = contacts.GetPhoneNumberByNumber(phoneNumber);
                DisplayContact.Printer.Print(found, "Contact details found by phone number:");
                break;
            }
            else if (choice == "3")
            {
                foreach (Contact contact in contacts.GetAllContacts())
                {
                    DisplayContact.Printer.Print(contact, "");
                }
                break;
            }
            else
            {
                Console.WriteLine("Invalid choice. Please choose 1 or 2.");
            }
        }

        }

}

