using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb1
{
    class Program
    {
        static void Main(string[] args)
        {
            Position p1 = new Position() { X = 2, Y = 5 };
            Position p2 = new Position() { X = 1, Y = 3 };
            Position p3 = new Position() { X = 5, Y = 4 };
            Position p4 = new Position() { X = 3, Y = 2 };
            Position p5 = new Position() { X = 3, Y = 3 };
            Position p0 = new Position() { X = 0, Y = 0 };

            SortedPosList sortedList = new SortedPosList();
            SortedPosList sortedList2 = new SortedPosList();

            sortedList.Add(p1);
            sortedList.Add(p2);
            sortedList.Add(p3);
            sortedList.Add(p4);

            sortedList2.Add(p3);
            sortedList2.Add(p4);
            sortedList2.Add(p5);

            sortedList.DisplayList();
            sortedList2.DisplayList();

            SortedPosList newList = sortedList - sortedList2;
            newList.DisplayList();

            SortedPosList newList2 = sortedList2 - sortedList;
            newList2.DisplayList();


            /*SortedPosList sortedList = new SortedPosList();
            SortedPosList sortedList2 = new SortedPosList();
            sortedList.Add(p1);
            sortedList.Add(p2);
            sortedList.Add(p3);
            sortedList2.Add(p4);
            sortedList2.Add(p5);
            sortedList.DisplayList();
            sortedList2.DisplayList();
            SortedPosList combineList = sortedList + sortedList2;
            p4.X = 10;
            p4.Y = 11;
            sortedList.Add(p4);

            sortedList.DisplayList();
            sortedList2.DisplayList();
            combineList.DisplayList();
            Console.WriteLine(sortedList[0]);
            Console.WriteLine(sortedList[1]);
            Console.WriteLine(sortedList[2]);

            Console.WriteLine(p3);
            Console.WriteLine(p4);
            Position p6 = p2 + p1;
            Console.WriteLine(p6);
            Position p7 = p4 - p3;
            Console.WriteLine(p7);
            Console.WriteLine(p3 % p4);
            Console.WriteLine(p4 % p3);
            Console.WriteLine(p1 % p3);

            Console.WriteLine(p1);
            Console.WriteLine(p2);
            Console.WriteLine(p3);
            Console.WriteLine(p4);

            Console.WriteLine(p1.Length());
            Console.WriteLine(p2.Length());
            Console.WriteLine(p3.Length());
            Console.WriteLine(p4.Length());

            Console.WriteLine(p1.Equals(p2));
            Console.WriteLine(p2.Equals(p3));
            Console.WriteLine(p3.Equals(p4));

            Console.WriteLine(p2);
            Position p5 = p2.Clone();
            Console.WriteLine(p5);
            Console.WriteLine(p5.Equals(p2));

            Console.WriteLine(p5 > p2);
            Console.WriteLine(p1 > p3);
            Console.WriteLine(p3 < p4);*/

            /*SortedPosList sortedList = new SortedPosList();
            sortedList.Add(p1);
            sortedList.Add(p2);
            sortedList.Add(p3);*/

            Console.ReadKey();
        }
    }
}
