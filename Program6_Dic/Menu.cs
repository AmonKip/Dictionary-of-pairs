using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FirstDataBase
{
    // THE CLASS OF MENUS

    public delegate void MenuAction();
    // type of a function to carry out a menu choice
    class Menu
    {
        private int numItems;
        private char theChoice;
        private String[] menuItems;
        private MenuAction[] theActions;

        public Menu(int howMany, String[] theMenu,
            MenuAction[] theMethods)
        {
            numItems = howMany;
            menuItems = theMenu;
            theActions = theMethods;
            theChoice = '0';
        }

        public void Display()
        {
            Console.WriteLine(
                "\n                        Main Menu\n\n");
            for (int i = 0; i < numItems; i++)
            {
                Console.Write("{0,20}. ", i + 1);
                Console.WriteLine(menuItems[i]);
            }
            Console.WriteLine();
        }

        public char GetChoice()
        {
            char maxChoice = (char)(numItems +
                 (int)'0');
            char aChoice;
            Console.Write(
                "Enter the NUMBER of your choice: ");
            aChoice = char.Parse(Console.ReadLine());
            while ((aChoice < 1) ||
                (aChoice > maxChoice))
            {
                Console.Write(
        "Please select a number between one and {0}",
                         maxChoice);
                aChoice =
                Char.Parse(Console.ReadLine());

            }
            theChoice = aChoice;
            return aChoice;
        }

        public bool Done()
        {
            return (theChoice == ((char)
                (numItems + '0')));
        }

        public void DoChoice(char c)
        {
            int line = c - '0' - 1;
            theActions[line]();

        }

        public void TypicalQuit()
        {
            char YesNo;
            Console.WriteLine(
                "\nQuitting the Program\n\n");
            Console.Write(
                "Are you SURE you want to quit? ");

            YesNo =
        Char.ToUpper(char.Parse(Console.ReadLine()));
            while ((YesNo != 'Y') && (YesNo != 'N'))
            {
                Console.Write("Please enter Y or N: ");
                YesNo =
        char.ToUpper(char.Parse(Console.ReadLine()));
            }
            if (YesNo == 'N')
            {
                theChoice = '0';
                Console.WriteLine(
                    "\nPress the ENTER key to continue");
            }
            else
            {
                Console.WriteLine(
                    "\nPress the Enter Key to finish up ....");
            }
        }
    }
}
