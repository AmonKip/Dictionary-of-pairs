using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace FirstDataBase
{
    // THE DICTIONARY CLASS
    class Dictionary
    {
        private const int DICSIZE = 100; // Set the dictionary capacity
        private int currentSize, CurrentLocation;
        private Pair[] theDic;
        public Pair FAIL = new Pair();

        public Dictionary()              // ?? OPEN FILE
        {
            theDic = new Pair[DICSIZE];
            currentSize = 0;
            CurrentLocation = 0;
        }

        public int AddPair(String w, String d)
        {
            if (currentSize == DICSIZE)
            {
                return -1;                // no space
            };
            if (FindByWord(w) != FAIL)
            {
                return -2;               //duplicate word
            }
            int location = 0;
            Pair wd = new Pair(w, d);
            while ((location < currentSize) &&
                (theDic[location] < wd))     // uses our <
            {
                location++;
            }
            for (int i = currentSize; i > location; i--)
            {
                theDic[i] = theDic[i - 1];
            }
            theDic[location] = wd;
            currentSize++;
            return 0;                  // successful insert
        }
        //*************************************************************************
        public int AddPair(Pair p)
        {
            if (currentSize == DICSIZE)
            {
                return -1;                // no space
            };
            if (FindByWord(p.TellWord()) != FAIL)
            {
                return -2;               //duplicate word
            }
            int location = 0;

            while ((location < currentSize) &&
                (theDic[location] < p))     // uses our <
            {
                location++;
            }
            for (int i = currentSize; i > location; i--)
            {
                theDic[i] = theDic[i - 1];
            }
            theDic[location] = p;
            currentSize++;
            return 0;                  // successful insert
        }
        //********************************************************************
        public Pair FindByWord(String w)
        {
            for (int i = 0; i < currentSize; i++)
            {
                if (theDic[i].TellWord() == w)
                {
                    return theDic[i];
                }
            }
            return FAIL;

        }

        public Boolean DeleteByWord(String w)
        {
            Pair where = FindByWord(w);
            if (where == FAIL)
            {
                return false;
            }
            else
            {
                int location = 0;
                while ((location < currentSize) &&
                    (theDic[location].TellWord() != w))
                // uses our =
                {
                    location++;
                }
                for (int i = location;
                    i < currentSize - 1; i++)
                {
                    theDic[i] = theDic[i + 1];
                }
                currentSize--;
                return true;
            }
        }

        public void List()
        {
            for (int i = 0; i < currentSize; i++)
            {
                Console.Write("{0,2}. ", i + 1);
                Console.WriteLine(theDic[i]);
                // uses our ToString() for the Pairs

            }
        }


        public bool IsEmpty()
        {
            return (currentSize == 0);
        }


        public bool IsFull()
        {
            return (currentSize == DICSIZE);
        }

        public int TellSize()
        {
            return currentSize;
        }

        public Pair TellFirst()    //part of iterator
        {
            if (IsEmpty())
            {
                return FAIL;
            }
            else
            {
                CurrentLocation = 0;
                return theDic[CurrentLocation];
            }
        }

        public Pair TellNext()  //   part of iterator
        {
            if (CurrentLocation == currentSize - 1)
            {
                return FAIL;
            }
            else
            {
                return theDic[++CurrentLocation];
            }

        }

        public bool DiskSave(String fileName)
        {
            StreamWriter w = new
             StreamWriter(fileName);
            //Do error checking
            for (int i = 0; i < currentSize; i++)
            {
                w.WriteLine(theDic[i].TellWord());
                w.WriteLine(theDic[i].TellDefinition());
            }
            w.Close();
            return true;
        }

        public bool DiskRecover(String fileName)
        {
            String tempWord, tempDefinition;
            Pair tempPair;
            currentSize = 0;
            StreamReader r;
            try  // so that it will work the first time
            {
                r = new StreamReader(fileName);

            }
            catch (FileNotFoundException)
            {
                return false;
            }
            while (((tempWord = r.ReadLine()) != null) &&
                ((tempDefinition = r.ReadLine()) != null)
            && (currentSize < DICSIZE) != false)
            {
                tempPair = new
                     Pair(tempWord, tempDefinition);
                AddPair(tempPair);
                // inefficient but okay   
            }

            r.Close();
            return true;
        }
    }
}
