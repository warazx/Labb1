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
            //Testar +, -, och % operationer på Positioner.
            Console.WriteLine(new Position(2, 4) + new Position(1, 2) + "\n");
            Console.WriteLine(new Position(2, 4) - new Position(1, 2) + "\n");
            Console.WriteLine(new Position(1, 2) - new Position(3, 6) + "\n");
            Console.WriteLine(new Position(3, 5) % new Position(1, 3) + "\n");

            //Skapar en lista och testar Remove metoden
            //Position (2,6) försvinner från listan.
            SortedPosList list1 = new SortedPosList();
            list1.Add(new Position(3, 7));
            list1.Add(new Position(1, 4));
            list1.Add(new Position(2, 6));
            list1.Add(new Position(2, 3));
            Console.WriteLine(list1 + "\n");
            list1.Remove(new Position(2, 6));
            Console.WriteLine(list1 + "\n");

            //Lägger till en till lista och försöker addera de 2 listorna med varandra.
            //Listorna ska skapa en ny lista med alla Positioner.
            SortedPosList list2 = new SortedPosList();
            list2.Add(new Position(3, 7));
            list2.Add(new Position(1, 2));
            list2.Add(new Position(3, 6));
            list2.Add(new Position(3, 3));
            list2.Add(new Position(2, 3));
            Console.WriteLine((list2 + list1) + "\n");

            Console.WriteLine("--- VG TEST ---");
            //Lägger till en lista med punkter, CircleContent kollar vilka Positioner
            // som ligger inom cirkelns area.
            SortedPosList circleList = new SortedPosList();
            circleList.Add(new Position(1, 1));
            circleList.Add(new Position(2, 2));
            circleList.Add(new Position(3, 3));
            Console.WriteLine(circleList.CircleContent(new Position(5, 5), 4) + "\n");

            //Genererar en ny lista, baserat på första listan, med duplikationer från
            // andra listan är borttagna. Resulterar endast unika kvar.
            SortedPosList list3 = new SortedPosList();
            list3.Add(new Position(3, 7));
            list3.Add(new Position(1, 2));  //unik
            list3.Add(new Position(4, 2));
            list3.Add(new Position(2, 5));  //unik
            SortedPosList list4 = new SortedPosList();
            list4.Add(new Position(3, 7));  //dup
            list4.Add(new Position(2, 1));  //finns ej
            list4.Add(new Position(4, 2));  //dup
            Console.WriteLine(list3 - list4);

            //Skapar en ny lista från filen som skickas med som argument,
            // finns inte namnet skapas en ny fil med det namnet.
            SortedPosList listFromFile1 = new SortedPosList("nyk.txt");
            Console.WriteLine("Imported from file: " + listFromFile1);

            //Lägger till en Position till listan, filen uppdateras automatiskt för varje aaddition.
            listFromFile1.Add(new Position(6, 3));
            Console.WriteLine("Added " + listFromFile1 + " to list.");

            Console.ReadLine();
        }
    }
}
