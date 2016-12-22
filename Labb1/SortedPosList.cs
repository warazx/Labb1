using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb1
{
    public class SortedPosList
    {
        private List<Position> positions = new List<Position>();
        private string filePath { get; set; }

        public SortedPosList() { }

        public SortedPosList(string filePath)
        {
            this.filePath = filePath;
            Load(filePath);
        }

        public int Count()
        {
            return positions.Count();
        }

        public void Add(Position pos)
        {
            Position p = new Position { X = pos.X, Y = pos.Y };
            positions.Add(p);
            SortList();
            if(filePath != null) Save();
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
            if(filePath != null)
            {
                Console.WriteLine($"The list '{filePath}' contains {Count()} positions:");
            }
            else
            {
                Console.WriteLine($"The list contains {Count()} positions:");
            }
            
            int i = 0;
            foreach(Position p in positions)
            {
                Console.WriteLine($"[{i++}]\t" + p + $"\t {p.Length()}");
            }
        }

        private void Load(string filePath)
        {
            try
            {
                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    int start1 = line.IndexOf('(') + 1;
                    int end1 = line.IndexOf(',');
                    int start2 = line.IndexOf(',') + 1;
                    int end2 = line.IndexOf(')');

                    int x = int.Parse(line.Substring(start1, end1 - start1));
                    int y = int.Parse(line.Substring(start2, end2 - start2));
                    Position pos = new Position { X = x, Y = y };
                    Add(pos);
                }
            }
            catch (FileNotFoundException)
            {
                this.filePath = filePath;
                File.Create(filePath).Close();
                Console.WriteLine($"No file found, created: {filePath}");
            }
            catch (FormatException)
            {
                Console.WriteLine($"Error parsing: {filePath}");
            }
            catch (Exception)
            {
                Console.WriteLine($"Error reading: {filePath}");
            }
        }

        private void Save()
        {
            string[] positionsAsStrings = new string[positions.Count()];
            int index = 0;
            foreach(Position p in positions)
            {
                positionsAsStrings[index++] = p.ToString();
            }

            try
            {
                File.WriteAllLines(filePath, positionsAsStrings);
            }
            catch (Exception)
            {
                Console.WriteLine($"Could not write to file: {filePath}");
            }
        }
    }
}
