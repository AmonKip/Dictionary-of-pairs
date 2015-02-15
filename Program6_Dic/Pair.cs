using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FirstDataBase
{
    // THE CLASS OF PAIRS: WORD + ANTONYM (THE
    // RECORDS IN OUR DATA BASE)

    class Pair
    {
        private String word, definition;

        public Pair() // null constructor
        {
            SetWord(null);
            SetDefinition(null);
        }

        public Pair(String w, String d)
        // conversion constructor
        {
            SetWord(w);
            SetDefinition(d);
        }

        public Pair(Pair p)
        {
            SetWord(p.TellWord());
            SetDefinition(p.TellDefinition());
        }

        public override bool Equals(object obj)
        // not used yet
        {
            if (!(obj is Pair))
            {
                return false;
            }

            Pair temp = (Pair)obj;
            return ((word == temp.word) && (definition
                 == temp.definition));

            // return base.Equals(obj);



        }

        public override int GetHashCode()
        // not used yet
        {

            return (word.GetHashCode() + definition.GetHashCode());
            // return base.GetHashCode();
        }

        public override string ToString()
        // tells how to write out a Pair
        {
            return (word + "\t" + definition);

            // return base.ToString;
        }

        public static bool operator ==(Pair p, Pair q)
        // how to compair Pairs
        {
            return ((p.word == q.word) && (p.definition == q.definition));
        }

        public static bool operator !=(Pair p, Pair q)
        {
            return !((p.word == q.word) &&
                (p.definition == q.definition));
        }

        public static bool operator <(Pair p, Pair q)
        {

            return (p.word.CompareTo(q.word) == -1);
        }

        public static bool operator >(Pair p, Pair q)
        {

            return (p.word.CompareTo(q.word) == 1);

        }

        public String TellWord()
        {
            return word;
        }

        public String TellDefinition()
        {
            return definition;
        }
        public void SetWord(String w)
        {
            word = w;
        }
        public void SetDefinition(String d)
        {
            definition = d;
        }
    }
}
