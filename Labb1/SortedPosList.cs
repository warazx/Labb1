using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb1
{
    public class SortedPosList
    {
        private List<Position> positions = new List<Position>();

        public int Count()
        {
            return positions.Count();
        }

        public void Add(Position pos)
        {
            Position p = new Position { X = pos.X, Y = pos.Y };
            positions.Add(p);
            SortList();
        }

        public bool Remove(Position pos)
        {
            Position itemToRemove = positions.SingleOrDefault(p => p.Equals(pos));
            return positions.Remove(itemToRemove);
        }

        public SortedPosList Clone()
        {
            SortedPosList newList = new SortedPosList();
            foreach (Position p in positions)
            {
                newList.Add(p.Clone());
            }            
            return newList;
        }

        public SortedPosList CircleContent(Position centerPos, double radius)
        {
            SortedPosList newList = new SortedPosList();
            foreach(Position p in positions)
            {
                if ((Math.Pow(p.X - centerPos.X, 2) + (Math.Pow(p.Y - centerPos.Y, 2))) < Math.Pow(radius, 2))
                {
                    newList.Add(p);
                }
            }
            return newList;
        }

        public static SortedPosList operator +(SortedPosList sp1, SortedPosList sp2)
        {
            SortedPosList newSP = sp1.Clone();
            foreach(Position p in sp2.positions)
            {
                newSP.Add(p);
            }
            return newSP;
        }

        public static SortedPosList operator -(SortedPosList sp1, SortedPosList sp2)
        {
            int index1 = 0;
            int index2 = 0;
            SortedPosList list1 = sp1.Clone();
            SortedPosList list2 = sp2.Clone();
            while (index1 < list1.Count() && index2 < list2.Count())
            {
                if(list1[index1].Equals(list2[index2]))
                {
                    list1.Remove(list1[index1]);
                }
                else
                {
                    if (list1[index1].Length() >= list2[index2].Length()) index2++;
                    else index1++;
                }
            }
            return list1;
        }

        public Position this[int index]
        {
            get { return positions[index]; }
        }

        private void SortList()
        {
            positions.Sort((emp1, emp2) => emp1.Length().CompareTo(emp2.Length()));
        }

        public void DisplayList()
        {
            Console.WriteLine($"The list contains {Count()} positions:");
            int i = 0;
            foreach(Position p in positions)
            {
                Console.WriteLine($"[{i++}]\t" + p + $"\t {p.Length()}");
            }
        }
    }
}
