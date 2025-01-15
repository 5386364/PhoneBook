using System;
using System.Collections.Generic;

namespace PhoneBook.SingletonFolder
{
    internal class DisplayContact
    {
       
        private static DisplayContact printer;

       
        public ConsoleColor CurrentColor { get; private set; } = ConsoleColor.Black;

        
        public static DisplayContact Printer
        {
            get
            {
                if (printer == null)
                {
                    printer = new DisplayContact();
                }
                return printer;
            }
        }

        
        public void Print(Contact contact, string header)
        {
            if (ConsoleColor.White != CurrentColor)
            {
                Console.ForegroundColor = ConsoleColor.White;      
                CurrentColor = ConsoleColor.White;
            }
            Console.WriteLine(header);

            PrintSeparator();

            if (contact != null && contact.Attributes.TryGetValue("Color", out object color))
            {
                if (Enum.TryParse(typeof(ConsoleColor), color.ToString(), true, out object parsedColor))
                {
                    Console.ForegroundColor = (ConsoleColor)parsedColor;
                }
            }

            if (contact == null)
            {
                Console.WriteLine("No contact information is available.");
            }
            else
            {
                Console.WriteLine(contact);
            }

            PrintSeparator();

            Reset();
        }

        private void PrintSeparator()
        {
            Console.WriteLine("===================================");
        }

        private void Reset()
        {
            if (ConsoleColor.Black != CurrentColor)
            {
                Console.ResetColor();
                CurrentColor = ConsoleColor.White;
            }
        }
    }
}
