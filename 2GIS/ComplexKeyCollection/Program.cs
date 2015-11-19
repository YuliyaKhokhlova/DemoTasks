using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexKeyCollection
{
    class NumberStr
    {
        public int Number { get; }
        public string Str { get; }

        public NumberStr(int n, string s)
        {
            Number = n;
            Str = s;
        }

        public override string ToString()
        {
            return Number.ToString() + "|" + Str;
        }
    }

    class Identifier
    {
        public int MajorId { get; }
        public int MinorId { get; }
    
        public Identifier(int major, int minor)
        {
            MajorId = major;
            MinorId = minor;
        }

        public override string ToString()
        {
            return MajorId.ToString() + "|" + MinorId.ToString();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Identifier))
            {
                return base.Equals(obj);
            }
            return MajorId == (obj as Identifier).MajorId && MinorId == (obj as Identifier).MinorId;
        }

        int multiplier = 197;
        public override int GetHashCode()
        {
            return multiplier * MajorId + MinorId;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            ComplexKeyCollection<int, string, string> col = new ComplexKeyCollection<int, string, string>();
            col[5, "hello"] = "Kitty";
            col.Add(5, "go", "Molly");
            col.Add(4, "hello", "Dolly");
            ShowUsage<int, string, string>(col);

            ComplexKeyCollection<Identifier, string, NumberStr> smth = new ComplexKeyCollection<Identifier, string, NumberStr>();
            smth[new Identifier(5, 4), "milk"] = new NumberStr(15, "bowl");
            smth.Add(new Identifier(3, 7), "juice", new NumberStr(2, "cup"));
            smth.Add(new Identifier(3, 7), "water", new NumberStr(2, "glass"));
            smth[new Identifier(5, 4), "milk"] = new NumberStr(15, "bottle");
            ShowUsage<Identifier, string, NumberStr>(smth);
            
        }

        private static void ShowUsage<TId, TName, TValue>(ComplexKeyCollection<TId, TName, TValue> collection)
        {
            Console.WriteLine("-------------------------");
            Console.WriteLine("Number of elements: " + collection.Count);
            Console.WriteLine("ID: " + typeof(TId));
            Console.WriteLine("Name: " + typeof(TName));
            Console.WriteLine("Value: " + typeof(TValue));
            foreach(KeyValuePair<ComplexKey<TId, TName>, TValue> element in collection)
            {
                Console.WriteLine("{0} - {1} - {2}", element.Key.Id, element.Key.Name, element.Value);
            }

            Console.WriteLine();
        }
    }
}
