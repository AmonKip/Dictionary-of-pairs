using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace FirstDataBase
{
    // A CLASS TO DEMONASTRATE DICTIONARIES (SMALL DATA 
   // BASES) AND MENUS

    class DicShow
    {
       static Dictionary myDic;
       static Menu myMenu;

        static void doAdd()
        {
            Console.WriteLine(
                "\n\n         ADDING A WORD\n\n");
            if (myDic.IsFull())
            {
                Console.WriteLine(
            "Dictionary Full: no more entries at this time\n");
            }
            else
            {
                String aWord, aDef;
                Console.Write("What is the Word? ");
                aWord = Console.ReadLine();
                Pair which = myDic.FindByWord(aWord);
                if (which != myDic.FAIL)
                {
                    Console.WriteLine(
            "We already have a pair with " + aWord +
                      " and the antonym " +
                      which.TellDefinition() + ".");
                }
                else
                {
                    Console.Write(
                    "What is the antonym? ");
                    aDef = Console.ReadLine();
                    Pair thePair =
                        new Pair(aWord, aDef);
                    myDic.AddPair(thePair);
                    Console.WriteLine(
                        "\n                   INSERTED\n");
                }

            }
        }

        static void doDelete()
        {
            Console.WriteLine("\nDELETING AN ITEM\n\n");
            if (myDic.IsEmpty())
            {
                Console.WriteLine(
            "There are no items to delete ");
            }
            else
            {
                Console.WriteLine(
                "What is the word to delete/ ");
                string theItem = Console.ReadLine();
                Pair thePair =
                    myDic.FindByWord(theItem);
                if (thePair == myDic.FAIL)
                {
                    Console.WriteLine(
            "This word is not IN the dictionary! \n\n");
                }
                else
                {
                    myDic.DeleteByWord(theItem);

                    Console.WriteLine("\nDeleted!\n\n");
                }
            }
        }


        static void doFind()
        {
            Console.WriteLine("\nFINDING AN ITEM\n\n");
            if (myDic.IsEmpty())
            {
                Console.WriteLine(
            "There are no entries to search through. \n");
            }


            else
            {

                Console.WriteLine(
            "What is the word to search for? ");
                String SearchWord = Console.ReadLine();
                Pair which =
                    myDic.FindByWord(SearchWord);
                if (which == myDic.FAIL)
                {
                    Console.WriteLine(
                "\nWe do not have the item \" " + SearchWord +
                            "\"\n\n");

                }
                else
                {
                    Console.WriteLine(
                "The antonym of " + SearchWord + " is "
                                   + which.TellDefinition() +
                                    "\n\n");
                }
            }
        }
        static void doList()
        {
            Console.WriteLine(
                "\n\nLISTING THE ITEMS \n\n");
            if (myDic.IsEmpty())
            {
                Console.WriteLine(
                    "Nothing to show yet\n");
            }
            else
            {
                myDic.List();
            }

        }
        static void doQuit()
        {
            myMenu.TypicalQuit();
        }

      static MenuAction[] theActs = {doAdd,
              doDelete, doFind, doList, doQuit};
      static String[] menuWords = {"Add a Pair",
                "Delete a Pair", "Find a Pair", 
                "List the Pairs", "Quit for Now"};


      static void Main(string[] args)
      {
          myDic = new Dictionary();
          myMenu = new Menu(5, menuWords, theActs);

          myDic.DiskRecover("diskdata.txt.");
          // initialize

          char ChoiceIn;
          do
          {
              myMenu.Display();
              ChoiceIn = myMenu.GetChoice();
              myMenu.DoChoice(ChoiceIn);
          }
          while (!(myMenu.Done()));

          myDic.DiskSave("diskdata.txt");
          // terminate



      }
      }
}